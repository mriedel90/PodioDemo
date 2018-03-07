using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PodioAPI;
using PodioAPI.Utils;

namespace PodioDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentIp = GetCurrentIpAddress();
            Console.WriteLine($"Your current IP is: {currentIp}");

            var appId = 0;
            var podio = new Podio("clientId", "clientSecret");
            podio.AuthenticateWithApp(appId, "appSecret");
            
            
            var items = podio.ItemService.FilterItems(appId);
            Console.WriteLine("My app has " + items.Total + " items");


            Console.ReadLine();
        }



        public static string GetCurrentIpAddress()
        {
            return new WebClient().DownloadString("http://icanhazip.com");
        }
    }
}
