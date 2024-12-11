using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termek
{
    internal class Termekek
    {
        private List<Termek> termeks;
        public Termekek()
        {

            Generalas();
        }

        public void Generalas()
        {
            termeks = new List<Termek>
            {
                new Termek(1, "Laptop", 120000, "Elektronika"),
                new Termek(2, "Okostelefon", 80000, "Elektronika"),
                new Termek(3, "Tablet", 60000, "Elektronika"),
                new Termek(4, "TV", 150000, "Elektronika"),
                new Termek(5, "Hűtőszekrény", 180000, "Háztartás"),
                new Termek(6, "Mosógép", 140000, "Háztartás"),
                new Termek(7, "Vasaló", 10000, "Háztartás"),
                new Termek(8, "Kenyérpirító", 7000, "Háztartás"),
                new Termek(9, "Szék", 20000, "Bútor"),
                new Termek(10, "Asztal", 40000, "Bútor"),
                new Termek(11, "Kanapé", 120000, "Bútor"),
                new Termek(12, "Szekrény", 100000, "Bútor"),
                new Termek(13, "Függöny", 8000, "Lakberendezés"),
                new Termek(14, "Lámpa", 12000, "Lakberendezés"),
                new Termek(15, "Ágy", 150000, "Bútor"),
                new Termek(16, "Toll", 500, "Irodaszer"),
                new Termek(17, "Jegyzetfüzet", 1500, "Irodaszer"),
                new Termek(18, "Monitor", 70000, "Elektronika"),
                new Termek(19, "Egér", 5000, "Elektronika"),
                new Termek(20, "Billentyűzet", 8000, "Elektronika"),
                new Termek(21, "Porzsák", 3000, "Háztartás"),
                new Termek(22, "Kávéfőző", 25000, "Háztartás"),
                new Termek(23, "Hátizsák", 15000, "Divat"),
                new Termek(24, "Cipő", 30000, "Divat"),
                new Termek(25, "Óra", 50000, "Divat"),
             };

        }

        public void Kiir()
        {
            foreach (var item in termeks)
            {
                Console.WriteLine(item);
            }
        }

        public List<string> TermekekNevei()
        {
            return termeks.Select(x => x.Nev).ToList();
        }
        public List<(string nev, double ar)> TermekekNeveiEsArai()
        {
            return termeks.Select(x => (x.Nev, x.Ar)).ToList();
        }

        public List<Termek> RendezesArSzerintNovekvobe()
        {
            return termeks.OrderBy(x => x.Ar).ToList();    
        }

        public List<(string nev, double ar)> RendezesCsokkenoSorrendben()
        {
            return termeks.OrderByDescending(x =>  x.Ar).Select(x => (x.Nev, x.Ar)).ToList() ;
        }

        public void DictionaryGyak()
        {
            Dictionary<string, int>stat = new Dictionary<string, int>();
            foreach (var item in termeks)
            {
                string key = item.Kategoria.ToString();
                if (!stat.ContainsKey(key))
                {
                    stat[key] = 0;
                }
                stat[key]++;
            }
            //foreach(KeyValuePair<string, int> item in termeks)
            //{
            //    Console.WriteLine(item.Key+" " + item.Value);
            //}
        }

        public List<Termek> DragaTermekek()
        {
            return termeks.Where(x => x.Ar > 10000000).ToList();
        }

        public IEnumerable<IGrouping<string, Termek>> Kategorizalas()
        {
            return termeks.GroupBy(x => x.Kategoria); 
        }

        public void Alapok()
        {
            var osszertek = termeks.Sum(x => x.Ar);
            Console.WriteLine($"A termékek összára: " + osszertek);
            osszertek = termeks.Where(x => x.Kategoria.Equals("Divat")).Sum(x => x.Ar);
            Console.WriteLine($"A divathoz kapcsolodó termékek összára: " + osszertek);

            var atlag = termeks.Where(x => x.Kategoria == "Elektronika").Average(x => x.Ar);
            Console.WriteLine($"Átlag ár: {atlag}");

            var db = termeks.Where(x => x.Azonosito % 2 == 0).Count();

            Console.WriteLine("db azonosító:" + db);

            var eredmeny = termeks.Where(x => x.Ar > 100000).OrderByDescending(x => x.Ar).Select(x => new { x.Nev, x.Ar }).ToList();
            foreach (var item in eredmeny)
            {
                Console.WriteLine("nev: " + item.Nev + " ar: " + item.Ar);
            }


        }

        public void ErtekSzerintKategoriak()
        {
            var eredmeny = termeks.GroupBy(x => x.Ar <=50000? "0-50000": x.Ar <= 1000000 ? "50001 - 100000" : "100000+" ).ToList();

            foreach( var item in eredmeny)
            {
                Console.WriteLine(item.Key);
                foreach ( var item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }
        }


        public void LegdragabbKategoriakkent()
        {
            var legdragabb = termeks.GroupBy(x => x.Kategoria).Select(x => new { Kategoria = x.Key, Legdragabb = x.OrderByDescending(a => a.Ar).First() });
            foreach(var item in legdragabb)
            {
                Console.WriteLine(item);
                
            }
        }


    }

}
