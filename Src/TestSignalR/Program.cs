using RealtimeSignIn;
using System;

namespace TestSignalR
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var signalR = new AzureSignalR("Endpoint=<url>;AccessKey=<key>;");
            var msg = Console.ReadLine();
            var result = signalR.SendAsync("chat", "new_msg",msg).ConfigureAwait(false);
            Console.WriteLine(result.GetAwaiter().GetResult().RequestMessage);
            Console.Read();
        }
    }
}
