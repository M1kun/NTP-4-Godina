using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace ntp
{
    public class Service : IService
    {
        public Komp Sabiranje(Komp k1, Komp k2)
        {
            Komp k3 = new Komp();
            k3.Real = k1.Real + k2.Real;
            k3.Imag = k1.Imag + k2.Imag;

            return k3;
        }
        public Komp Oduzimanje(Komp k1, Komp k2)
        {
            Komp k3 = new Komp();
            k3.Real = k1.Real - k2.Real;
            k3.Imag = k1.Imag - k2.Imag;

            return k3;
        }
        public Komp Mnozenje(Komp k1, Komp k2)
        {
            Komp k3 = new Komp();
            k3.Real = k1.Real * k2.Real - k1.Imag * k2.Imag;
            k3.Imag = k1.Real*k2.Imag + k1.Imag*k2.Real;

            return k3;
        }
        public Komp Deljenje(Komp k1, Komp k2)
        {
            Komp k3 = new Komp();
            k3.Real = (k1.Real * k2.Real + k1.Imag * k2.Imag) / (k2.Real * k2.Real + k2.Imag * k2.Imag);
            k3.Imag = (k1.Imag * k2.Real - k1.Real * k2.Imag) / (k2.Real * k2.Real + k2.Imag * k2.Imag);

            return k3;
        }
    }
}
