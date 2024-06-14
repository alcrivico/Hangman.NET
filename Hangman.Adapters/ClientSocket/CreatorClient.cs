using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Adapters.ClientSocket
{
    public class CreatorClient
    {

        private static TcpClient client;
        private static NetworkStream stream;

        public static void Start()
        {

            client = new TcpClient("127.0.0.1", 5000);

            Console.WriteLine("Connected to server.");

            stream = client.GetStream();

            Thread listenThread = new Thread(Listen);

            listenThread.Start();

        }

        private static void Listen()
        {

            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {

                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine("Received from server: " + message);

                if (message == "Game Over")
                {

                    Console.WriteLine("Game Over");

                    break;

                }

            }

            CloseConnection();

        }

        private static void CloseConnection()
        {

            stream.Close();
            client.Close();
            Console.WriteLine("Connection closed.");

        }

    }

}
