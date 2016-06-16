using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LightControl.Web.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;

namespace LightControl.Web.Controllers
{
    public class LightController : ApiController
    {

        //private string ServerURI = "http://localhost:23790/signalr";
        //public HubConnection Connection { get; set; }
        //public IHubProxy HubProxy { get; set; }

        [Route("api/Light")]
        public bool GetLightOn(bool l1,
                               bool l2,
                               bool l3,
                               bool l4,
                               bool l5,
                               bool l6,
                               bool l7,
                               bool l8,
                               bool l9,
                               bool l10,
                               bool l11,
                               bool l12)
        {
            try
            {
                var hubContext = GlobalHost.ConnectionManager.GetHubContext<LightHub>();

                var message = $"l1={l1}&l2={l2}&l3={l3}&l4={l4}&l5={l5}&l6={l6}&l7={l7}&l8={l8}&l9={l9}&l10={l10}&l11={l11}&l12={l12}";

                hubContext.Clients.All.AddMessage("lights", message);

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }

            ////SignalRSender signalRSender = new SignalRSender(Connection);

            ////    Connection = new HubConnection(ServerURI);
            ////    Connection.Closed += Connection_Closed;
            ////    HubProxy = Connection.CreateHubProxy("LightHub");

            //    HubProxy.Invoke("Send", "UserName", "TextBoxMessage.Text");
        }

        private void Connection_Closed()
        {

        }
    }
}
