using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ntp;

namespace Klijent
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IService> factory = new ChannelFactory<IService>(
                                        new NetTcpBinding(),
                                        new EndpointAddress("net.tcp://localhost:4000/IWCFService"));

            IService proxy = factory.CreateChannel();
            string operacija = "";
            do
            {
                IspisiMeni();
                operacija = Console.ReadLine();
                if (operacija.Equals("+") || operacija.Equals("-") || operacija.Equals("/") || operacija.Equals("*"))
                {
                    Console.WriteLine("Unesite prvi broj");
                    Komp a = new Komp();
                    a.Real = double.Parse(Console.ReadLine());
                    a.Imag = double.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite drugi broj");
                    Komp b = new Komp();
                    b.Real = double.Parse(Console.ReadLine());
                    b.Imag = double.Parse(Console.ReadLine());
                    Komp rez = new Komp();
                    switch (operacija)
                    {
                        case "+":
                            rez = proxy.Sabiranje(a, b);
                            break;
                        case "-":
                            rez = proxy.Oduzimanje(a, b);
                            break;
                        case "*":
                            rez = proxy.Mnozenje(a, b);
                            break;
                        case "/":
                            rez = proxy.Deljenje(a, b);
                            break;
                    }
                    Console.WriteLine("Rezultat je {0}", rez);
                }
                else
                {
                    Console.WriteLine("Morate uneti neku od ponudjenih operacija.");
                }
            } while (!operacija.ToLower().Equals("e"));

        }

        static void IspisiMeni()
        {
            Console.WriteLine("Unesite operaciju koju zelite da izvrsite");
            Console.WriteLine("+ za sabiranje");
            Console.WriteLine("- za oduzimanje");
            Console.WriteLine("* za mnozenje");
            Console.WriteLine("/ za deljenje");
            Console.WriteLine("e za prekid programa");
        }
    }
}
