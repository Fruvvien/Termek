using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Termek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Termekek t = new Termekek();
            t.Kiir();

            t.TermekekNevei().ForEach(x => Console.WriteLine(x));

            t.TermekekNeveiEsArai().ForEach(x => Console.WriteLine(x.nev + ": " +x.ar));

            t.RendezesArSzerintNovekvobe().ForEach(x => Console.WriteLine(x.Ar));

            t.RendezesCsokkenoSorrendben().ForEach(x => Console.WriteLine("nev: " + x.nev + "ar: "+  x.ar));
            t.DragaTermekek().ForEach(x => Console.WriteLine(x));

            var csoportok = t.Kategorizalas();
            foreach (var c in csoportok)
            {
                Console.WriteLine(c.Key);
                foreach (var c2 in c)
                {
                    Console.WriteLine(c2);
                }
            }

            t.Alapok();

            t.ErtekSzerintKategoriak();
            t.LegdragabbKategoriakkent();
        }
    }
}
