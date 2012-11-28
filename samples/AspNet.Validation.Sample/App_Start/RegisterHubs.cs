using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hosting.AspNet;
using SignalR.Validation;

[assembly: PreApplicationStartMethod(typeof(AspNet.Validation.Sample.RegisterHubs), "Start")]

namespace AspNet.Validation.Sample
{
    public static class RegisterHubs
    {
        public static void Start()
        {
            // Register the default hubs route: ~/signalr/hubs
            GlobalHost.HubPipeline.AddModule(new ValidationModule());
            RouteTable.Routes.MapHubs();            
        }
    }
}
