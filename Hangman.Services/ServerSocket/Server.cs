using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

namespace Hangman.Services.ServerSocket
{
    public class Server
    {

        private static TcpListener server;
        private static TcpClient creatorClient;
        private static TcpClient challengerClient;
        private static NetworkStream creatorStream;
        private static NetworkStream challengerStream;

        public static void Start()
        {

            server = new TcpListener(IPAddress.Any, 5000);

            server.Start();
            Console.WriteLine("Server started...");

            // Espera por el CreatorSocketClient

            creatorClient = server.AcceptTcpClient();

            Console.WriteLine("Creator connected.");

            creatorStream = creatorClient.GetStream();

            // Espera por el ChallengerSocketClient

            challengerClient = server.AcceptTcpClient();

            Console.WriteLine("Challenger connected.");

            challengerStream = challengerClient.GetStream();

            // Comienza a escuchar al Challenger

            Thread challengerThread = new Thread(ListenToChallenger);

            challengerThread.Start();

        }

        private static void ListenToChallenger()
        {

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = challengerStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                Console.WriteLine("Received data from challenger.");

                // Envía los datos recibidos al Creator

                creatorStream.Write(buffer, 0, bytesRead);

                Console.WriteLine("Data sent to creator.");

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                if (message == "Game Over")
                {

                    Console.WriteLine("Game Over");

                    break;

                }

            }

            CloseConnections();

        }

        private static void CloseConnections()
        {

            challengerStream.Close();
            creatorStream.Close();
            challengerClient.Close();
            creatorClient.Close();
            server.Stop();
            Console.WriteLine("Server stopped.");

        }

    }

}