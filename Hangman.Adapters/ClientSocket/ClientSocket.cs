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

        private Socket _clientSocket;
        private IPEndPoint _serverAddress;

        public ClientSocket()
        {
            _serverAddress = new IPEndPoint(IPAddress.Parse(SERVER_IP), SERVER_PORT);
            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartClientSocket()
        {
            try
            {
                _clientSocket.Connect(_serverAddress);
                Console.WriteLine("Connected to the server");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void SendMessage(string message)
        {
            if (_clientSocket.Connected)
            {
                byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                try
                {
                    _clientSocket.Send(sendBytes);
                    Console.WriteLine("Message sent: " + message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending message: " + ex.Message);
                }
            }
        }

        public string ReceiveMessage()
        {
            if(_clientSocket.Connected)
            {
                byte[] receiveBytes = new byte[1024];
                try
                {
                    int numBytes = _clientSocket.Receive(receiveBytes);
                    string serverMessage = Encoding.UTF8.GetString(receiveBytes, 0, numBytes);
                    Console.WriteLine("Received from server: " + serverMessage);

                    return serverMessage;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error receiving message: " + ex.Message);
                }
            }
            return "Error";
        }

        public void CloseConnection()
        {
            if (_clientSocket.Connected)
            {
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
        }
    }
}
