using Hangman.ServerSocket;

internal class Program
{

    private static void Main(string[] args)
    {

        Thread serverThread = new Thread(Server.Start);

        serverThread.Start();

    }

}