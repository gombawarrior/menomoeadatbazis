using System;
using System.IO;
using System.Linq;

namespace DuncikaMoexd
{
    class Olvasgató
    {
        static private readonly string ösvény = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly string almappaösvény = Path.Combine(ösvény, "Sziasztokfiúk");
        private readonly StreamReader sr;
        public Olvasgató(ref bool poen)
        {
            try
            {
                sr = new StreamReader(almappaösvény + @"\adatbázisolt.txt");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("\nnem található adatbázis, előbb töltsd fel\n");
                Console.ReadLine();
                poen = true;
                return;
            }
        }

        #region templátum
        private void Templátum(int i, string[] s)
        {

            Console.SetCursorPosition(0, i + 4);
            Console.WriteLine(s[0]);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(15, i + 4);
            if(s[1] == "0")
                Console.WriteLine("TBA");
            else
                Console.Write(s[1]);
            Console.SetCursorPosition(20, i + 4);
            Console.ResetColor();
            Console.WriteLine("|");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(23, i + 4);
            if(s[2] == "0")
                Console.WriteLine("TBA");
            else
                Console.Write(s[2]);
            Console.SetCursorPosition(28, i + 4);
            Console.ResetColor();
            Console.WriteLine("|");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(31, i + 4);
            if(s[3] == "0")
                Console.WriteLine("TBA");
            else
                Console.Write(s[3]);
            Console.SetCursorPosition(36, i + 4);
            Console.ResetColor();
            Console.WriteLine("|");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(39, i + 4);
            if(s[4] == "0")
                Console.WriteLine("TBA");
            else
                Console.Write(s[4]);
            Console.SetCursorPosition(45, i + 4);
            Console.ResetColor();
            Console.WriteLine("|");
        }
        #endregion

        #region fejléc
        public void Mindentkiirfejléc(int a, string keresTank)
        {
            Console.Clear();
            Console.WriteLine("Hallo Fame");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Harckocsi");

            Console.SetCursorPosition(15, 2);
            Console.WriteLine("1st  |");

            Console.SetCursorPosition(23, 2);
            Console.WriteLine("2nd  |");

            Console.SetCursorPosition(31, 2);
            Console.WriteLine("3nd  |");

            Console.SetCursorPosition(39, 2);
            Console.WriteLine("100%  |");

            Console.SetCursorPosition(0, 3);
            for(int i = 0; i < 46; i++)
            {
                Console.Write('\u2014');
            }
            switch(a)
            {
                case 1:
                    Mindetkiír();
                    break;
                case 2:
                    Kiirszerkeszt(keresTank);
                    break;
            }
        }
        #endregion
        public void Mindetkiír()
        {
            for(int i = 0; !sr.EndOfStream; i++)
            {
                string sor = sr.ReadLine();
                string[] s = sor.Split('¤');

                Templátum(i, s);

            }
            Console.ReadLine();
            sr.Close();
        }

        #region bugosszarszerkesztő
        public void Kiirszerkeszt(string keresTank)
        {
            Lista a = new Lista();
            while(!sr.EndOfStream)
            {
                    string sor = sr.ReadLine();
                    string[] s = sor.Split('¤');
                Lista.Adatosstrukt seged = new Lista.Adatosstrukt
                {
                    tanknev = s[0],
                    elsomark = Convert.ToUInt16(s[1]),
                    masodikmark = Convert.ToUInt16(s[2]),
                    harmadikmark = Convert.ToUInt16(s[3]),
                    száz = Convert.ToUInt16(s[4])
                };

                a.menőlista.Add(seged);
            }
            sr.Close();
            int id = a.menőlista.FindIndex(x => x.tanknev == keresTank);
            if(id != -1)
            {
                string specsor = File.ReadLines(almappaösvény + @"\adatbázisolt.txt").Skip(id).FirstOrDefault();
                string[] s = specsor.Split('¤');
                Templátum(1, s);
                Console.WriteLine("\n\nadat szerkesztése... (i/n)");
                string szerkeszt = Console.ReadLine().ToLower();
                if(szerkeszt=="i")
                {
                    Lista.Adatosstrukt temp = a.menőlista[id];
                    bool nemmehettovább = false;
                    do
                    {
                        nemmehettovább = false;
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\naz első mark csataszáma (0, ha még nincs): ");
                            temp.elsomark = Convert.ToUInt16(Console.ReadLine());

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("a második mark csataszáma (0, ha még nincs): ");
                            temp.masodikmark = Convert.ToUInt16(Console.ReadLine());

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("a harmadik mark csataszáma (0, ha még nincs): ");
                            temp.harmadikmark = Convert.ToUInt16(Console.ReadLine());

                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("a 100%moi csataszáma (0, ha még nincs): ");
                            temp.száz = Convert.ToUInt16(Console.ReadLine());
                        }
                        catch(Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nilyet ne írj ide >:O");
                            Console.ForegroundColor = ConsoleColor.White;
                            nemmehettovább = true;
                        }
                    } while(nemmehettovább);

                    Console.ResetColor();
                    a.menőlista[id] = temp;

                    Irogató visszaír = new Irogató(true);
                    visszaír.Ujadatki(a);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nmentve...");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nvisszalépés...");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\na keresett tank, \"{keresTank}\", nem található az adatbázisban");
                Console.ResetColor();
            }
            Console.ReadLine();
        }
    }
}
        #endregion
