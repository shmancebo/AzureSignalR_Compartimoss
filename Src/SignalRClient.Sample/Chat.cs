using Microsoft.AspNetCore.SignalR;

namespace chattest
{

    public class Chat : Hub
    {
        public void BroadcastMessage(string name, string message)
        {
            Clients.All.SendAsync("new_msg", name, message);
        }

    }
}
