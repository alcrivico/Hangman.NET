using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Hangman.ServerSocket
{
    public class Server
    {
        private static TcpListener server;
        private static Dictionary<string, GameSession> games = new Dictionary<string, GameSession>();

        public static void Start()
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
            }
            catch
            {
                client.Close();
                return;
            }

            string gameCode = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();

            lock (games)
            {
                if (!games.ContainsKey(gameCode))
                {
                    games[gameCode] = new GameSession();
                    games[gameCode].CreatorClient = client;
                    games[gameCode].CreatorStream = stream;
                    Console.WriteLine($"Creator connected for game {gameCode}.");
                }
                else if (games[gameCode].ChallengerClient == null)
                {
                    games[gameCode].ChallengerClient = client;
                    games[gameCode].ChallengerStream = stream;
                    Console.WriteLine($"Challenger connected for game {gameCode}.");
                    Thread challengerThread = new Thread(() => ListenToChallenger(gameCode));
                    challengerThread.Start();
                }
                else
                {
                    Console.WriteLine($"Game {gameCode} already has two players. Closing connection.");
                    stream.Close();
                    client.Close();
                }
            }
        }

        private static void ListenToChallenger(string gameCode)
        {
            GameSession session;
            lock (games)
            {
                session = games[gameCode];
            }

            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = session.ChallengerStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    Console.WriteLine($"Received data from challenger for game {gameCode}.");

                    session.CreatorStream.Write(buffer, 0, bytesRead);

                    Console.WriteLine($"Data sent to creator for game {gameCode}.");

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (message == "Game Over")
                    {
                        Console.WriteLine($"Game Over for game {gameCode}");
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine($"Challenger disconnected for game {gameCode}. Closing connections.");
                CloseConnections(gameCode);
            }

            CloseConnections(gameCode);
        }

        private static void CloseConnections(string gameCode)
        {
            lock (games)
            {
                if (games.ContainsKey(gameCode))
                {
                    GameSession session = games[gameCode];

                    try
                    {
                        session.ChallengerStream.Close();
                        session.ChallengerClient.Close();
                    }
                    catch { }

                    try
                    {
                        session.CreatorStream.Close();
                        session.CreatorClient.Close();
                    }
                    catch { }

                    games.Remove(gameCode);
                    Console.WriteLine($"Game {gameCode} connections closed.");
                }
            }
        }
    }

    public class GameSession
    {
        public TcpClient CreatorClient { get; set; }
        public TcpClient ChallengerClient { get; set; }
        public NetworkStream CreatorStream { get; set; }
        public NetworkStream ChallengerStream { get; set; }
    }
}
