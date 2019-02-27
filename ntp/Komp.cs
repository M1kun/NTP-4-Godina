using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntp
{
        public class Komp
    {
        private double real;
        private double imag;

        public double Real { get => real; set => real = value; }
        public double Imag { get => imag; set => imag = value; }

        public Komp(double r, double i)
        {
            this.Real = r;
            this.Imag = i;
        }
        public Komp()
        {
            Real = 0;
            Imag = 0;
        }
        public override string ToString()
        {
            string s = "";
            s += Real + " + " + Imag + "i";
            return s;
        }

    }
}
