using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;

namespace Hangman.Services.ServerSocket
{
    
    public class ServerSocket
    {
        private const string SERVER_IP = "127.0.0.1";
        private const int SERVER_PORT = 1002;

        private Socket _serverSocket;
        private List<Socket> _clientSockets = new List<Socket>();
        private bool _isRunning = false;

        public void StartServerSocket()
        {
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(SERVER_IP), SERVER_PORT);
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(serverAddress);
            _serverSocket.Listen(10);

            _isRunning = true;
            Console.WriteLine("Server is listening for incoming connections");

            while (_isRunning)
            {
                try
                {
                    Socket clientSocket = _serverSocket.Accept();
                    _clientSockets.Add(clientSocket);
                    Console.WriteLine("Client connected");

                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void HandleClient(Socket clientSocket)
        {
            while (_isRunning)
            {
                try
                {
                    byte[] receivedBytes = new byte[1024];
                    
                }
            }
        }
    }
}