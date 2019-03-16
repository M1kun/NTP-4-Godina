using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Servis));
            host.AddServiceEndpoint(typeof(IServis),
                                    new NetTcpBinding(),
                                    new Uri("net.tcp://localhost:8000"));
            host.Open();
            Console.WriteLine("Host je otvoren");
            Console.ReadKey();
            host.Close();
        }
    }
}
