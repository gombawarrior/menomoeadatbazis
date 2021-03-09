using System;
using System.Collections.Generic;
using System.IO;

namespace DuncikaMoexd
{
    class Irogató
    {
        static private readonly string ösvény = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly string almappaösvény = Path.Combine(ösvény, "Sziasztokfiúk");
        private readonly StreamWriter sw;
        public Irogató(bool felülír)
        {
            Directory.CreateDirectory(almappaösvény);
            if(!felülír)
                sw = new StreamWriter(almappaösvény + @"\adatbázisolt.txt", true);
            else
                sw = new StreamWriter(almappaösvény + @"\adatbázisolt.txt", false);
        }

        #region adatbe
        public void Ujadatbe()
        {
            Lista pocok = new Lista();
            string elégvolt = "n";
            while (elégvolt=="n")
            {
                Console.Clear();
                Console.WriteLine("írd be szépen az adatokat, és nem lesz baj (elvileg)");
                Console.WriteLine("1 - vissza\n");


                Lista.Adatosstrukt seged = new Lista.Adatosstrukt();
                Console.Write("a tank PONTOS neve (vagy 1): ");
                seged.tanknev = Console.ReadLine();

                if (seged.tanknev=="1")
                {
                    goto Vissza;
                }

                bool nemmehettovább;
                do
                {
                    try
                    {
                        nemmehettovább = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("az első mark csataszáma (0, ha még nincs): ");
                        seged.elsomark = Convert.ToUInt16(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("a második mark csataszáma (0, ha még nincs): ");
                        seged.masodikmark = Convert.ToUInt16(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("a harmadik mark csataszáma (0, ha még nincs): ");
                        seged.harmadikmark = Convert.ToUInt16(Console.ReadLine());

                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("a 100%moi csataszáma (0, ha még nincs): ");
                        seged.száz = Convert.ToUInt16(Console.ReadLine());
                    }
                    catch(Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nilyet ne írj ide >:O");
                        Console.ForegroundColor = ConsoleColor.White;
                        nemmehettovább = true;
                    }

                } while(nemmehettovább);

                    Console.ForegroundColor = ConsoleColor.White;
                pocok.menőlista.Add(seged);
                Console.Write("\nelégvolt? (i/n) ");
                elégvolt = Console.ReadLine().ToLower();
            }
            Ujadatki(pocok);
        Vissza:
            sw.Close();
        }
        #endregion

        public void Ujadatki(Lista pocok)
        {
            foreach (Lista.Adatosstrukt x in pocok.menőlista)
            {
                sw.WriteLine($"{x.tanknev}¤{x.elsomark}¤{x.masodikmark}¤{x.harmadikmark}¤{x.száz}");
            }
            sw.Close();
        }

        #region törlőnemtommérittvan
        public void Törlés()
        {
            sw.Close();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nbiztos ki szeretnéd törölni???? (i/n) ");
            string ige = Console.ReadLine().ToLower();
            if(ige == "i")
            {
                File.Delete(almappaösvény + @"\adatbázisolt.txt");
                Console.WriteLine("\n\ntörölve...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nnem lett törölve...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }
        #endregion
    }
}
