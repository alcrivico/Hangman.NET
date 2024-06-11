// See https://aka.ms/new-console-template for more information
using SocketServerImplementation;

Console.WriteLine("Aplicacion socket servidor");
ServerSocket socketServidor = new ServerSocket();
socketServidor.StartServerSocket();
