using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace ntp
{
    class Program
    {
        static void Main(string[] args)
        {
            string adresa = "net.tcp://localhost:4000/IWCFService";
            ServiceHost server = new ServiceHost(typeof(Service));
            server.AddServiceEndpoint(typeof(IService),
                                                 new NetTcpBinding(),
                                      new Uri(adresa));
            server.Open();
            Console.WriteLine("Host je otvoren na adresi : {0}", adresa);
            Console.ReadLine();
            server.Close();

        }
    }
    }

