using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LightControl.Web.Controllers;
using LightControl.Web.Hubs;
using Microsoft.AspNet.SignalR;

namespace LightControl.Web
{
    public class SignalRSender
    {
        // Singleton instance
        private static readonly Lazy<SignalRSender> Instance = new Lazy<SignalRSender>(
            () => new SignalRSender(GlobalHost.ConnectionManager.GetHubContext<LightHub>()));

        private readonly IHubContext _context;

        public SignalRSender(IHubContext context)
        {
            _context = context;
        }
        
        public void SendMessage(string message)
        {
            Instance.Value._context.Clients.All.AddMessage(message);
            _context.Clients.All.AddMessage(message);
        }
    }
}