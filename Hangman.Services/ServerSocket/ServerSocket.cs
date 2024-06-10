using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace Hangman.Services.ServerSocket
{
    
    public class ServerSocket
    {
        const string SERVER_IP = "127.0.0.1";
        const int SERVER_PORT = 1002;

        public void StartServerSocket()
        {
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(SERVER_IP), SERVER_PORT);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(serverAddress);
            serverSocket.Listen(10);//Pendiente, ¿agrego proyecto completo de sockets?
            Console.WriteLine("Server is listening for incoming connections");

            try
            {
                Socket remoteClientSocket = serverSocket.Accept();
                Console.WriteLine("Client connected");
                string receivedMessage = "";

                do
                {
                    byte[] receivedBytes = new byte[1024];
                    remoteClientSocket.Receive(receivedBytes, 0, receivedBytes.Length, 0);
                    receivedMessage = Encoding.UTF8.GetString(receivedBytes);
                    Console.WriteLine("Client says: " + receivedMessage);

                    string serverMessage = "hello";
                    byte[] sendBytes = Encoding.UTF8.GetBytes(serverMessage);
                    remoteClientSocket.Send(sendBytes);
                    Console.WriteLine("Server says: " + serverMessage);
                } while (!receivedMessage.Equals("exit"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                serverSocket.Close();
            }
            Console.WriteLine("Server closed");
        }
    }
}