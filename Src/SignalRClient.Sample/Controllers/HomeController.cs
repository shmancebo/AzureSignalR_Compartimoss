using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalRClient.Sample.Models;
using Microsoft.AspNetCore.SignalR;
using chattest;

namespace SignalRClient.Sample.Controllers
{
    public class HomeController : Controller
    {
        IHubContext<Chat> context;
        public HomeController(IHubContext<chattest.Chat> hub)
        {
            context = hub;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public void AddMsg(string msg)
        {
            context.Clients.All.SendAsync("new_msg", msg);
        }
    }
}
