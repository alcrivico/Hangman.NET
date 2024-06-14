using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Adapters.ClientSocket
{

    public class ChallengerClient
    {

        private static TcpClient _client;
        private static NetworkStream _stream;
        private static string _message = string.Empty;

        public static void Start()
        {

            _client = new TcpClient("127.0.0.1", 5000);

            Console.WriteLine("Connected to server.");

            _stream = _client.GetStream();

            do
            {
                Console.Write("Send Message: ");
                _message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(_message);

                _stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: " + _message);
                Thread.Sleep(1000); // Pausa de 1 segundo entre mensajes

            } while (!_message.Equals("Game Over"));

            CloseConnection();

        }

        private static void CloseConnection()
        {

            _stream.Close();
            _client.Close();
            Console.WriteLine("Connection closed.");

        }

    }

}
