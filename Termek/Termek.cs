using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termek
{
    internal class Termek
    {
        private int azonosito;
        private string nev;
        private double ar;
        private string kategoria;

        public Termek(int azonosito, string nev, double ar, string kategoria)
        {
            this.azonosito = azonosito;
            this.nev = nev;
            this.ar = ar;
            this.kategoria = kategoria;
        }

        public int Azonosito { get => azonosito; }
        public string Nev { get => nev;  }
        public double Ar { get => ar; set => ar = value; }
        public string Kategoria { get => kategoria; }

        public override string ToString()
        {
            return $"{this.azonosito}. {this.nev} {this.ar} {this.kategoria}";
        }
    }
}
