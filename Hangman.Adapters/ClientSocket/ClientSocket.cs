using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Adapters.ClientSocket
{
    internal class ClientSocket
    {
        const string SERVER_IP = "127.0.0.1";
        const int SERVER_PORT = 1002;

        public void StartClientSocket()
        {
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(SERVER_IP), SERVER_PORT);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(serverAddress);
                Console.WriteLine("Connected to the server");
                string clientMessage = "";

                do
                {
                    Console.Write("Enter a message to send to the server: ");
                    clientMessage = Console.ReadLine();
                    byte[] sendBytes = Encoding.UTF8.GetBytes(clientMessage);
                    clientSocket.Send(sendBytes);

                    byte[] receiveBytes = new byte[1024];
                    clientSocket.Receive(receiveBytes, 0, receiveBytes.Length, 0);
                    string serverMessage = Encoding.UTF8.GetString(receiveBytes);
                    Console.WriteLine("Server says: " + serverMessage);

                } while (clientMessage != "exit");

                clientSocket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                clientSocket.Close();
            }
        }
    }
}
