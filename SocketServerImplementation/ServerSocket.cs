using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketServerImplementation
{
    internal class ServerSocket
    {
        private const string SERVER_IP = "127.0.0.1";
        private const int SERVER_PORT = 1002;

        private Socket _serverSocket;
        private Dictionary<String, Socket> _clientSockets = new Dictionary<string, Socket>();
        private bool _isRunning = false;

        public void StartServerSocket()
        {
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(SERVER_IP), SERVER_PORT);
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Bind(serverAddress);
            _serverSocket.Listen();

            _isRunning = true;
            Console.WriteLine("Server is listening for incoming connections");

            while (_isRunning)
            {
                try
                {
                    
                    Socket clientSocket = _serverSocket.Accept();
                    //string clientIP = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();
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
                    int receivedBytesCount = clientSocket.Receive(receivedBytes);
                    if (receivedBytesCount == 0)
                        return;

                    string text = Encoding.UTF8.GetString(receivedBytes, 0, receivedBytesCount);
                    Console.WriteLine("Message received: " + text);

                    if (text.Length > 10)
                    {
                        _clientSockets.Add(text, clientSocket);
                    }
                    foreach (var socket in _clientSockets)
                    {
                        if (socket.Value != clientSocket && socket.Key == text)
                        {
                            socket.Value.Send(receivedBytes, receivedBytesCount, SocketFlags.None);
                        }
                    }

                }
                catch (SocketException socketEx)
                {
                    Console.WriteLine("Error: " + socketEx.Message);
                    foreach (var socket in _clientSockets)
                    {
                        if (socket.Value == clientSocket)
                        {
                            _clientSockets.Remove(socket.Key);
                            break;
                        }
                    }
                    clientSocket.Close();
                    break;
                }
            }
        }

        public void StopServerSocket()
        {
            _isRunning = false;
            
            foreach (var socket in _clientSockets)
            {
                Socket clientSocket = socket.Value;
                try
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("Socket error shutting down: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General error shutting down: " + ex.Message);
                }
                finally
                {
                    clientSocket.Close();
                }
            }
            _serverSocket.Close();
            Console.WriteLine("Server stopped");
        }
    }
}
