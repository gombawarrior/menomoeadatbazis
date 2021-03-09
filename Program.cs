using System;

namespace DuncikaMoexd
{
    class Program
    {
        static void Olvasó(bool nemmehettovább)
        {
            do
            {
                bool nincsfile = false;
                nincsfile:
                if(!nincsfile)
                {
                    string keresTank = "";
                    byte switch_on = 0;
                    do
                    {
                        nemmehettovább = false;
                        Console.Clear();
                        Console.WriteLine(">>a tárolt adatok megjelenítése<<\n\n");
                        Console.WriteLine("1 - minden adat megjelenítése");
                        Console.WriteLine("2 - egy bizonyos tank statisztikájának megjelenítése");
                        Console.WriteLine("3 - vissza\n");
                        try
                        {
                            switch_on = Convert.ToByte(Console.ReadLine());
                        }
                        catch(Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nilyet ne írj ide >:O");
                            Console.ForegroundColor = ConsoleColor.White;
                            nemmehettovább = true;
                            Console.ReadLine();
                        }
                    } while(nemmehettovább);

                    switch(switch_on)
                    {
                        case 1:
                        {
                            Olvasgató olvassálsokat = new Olvasgató(ref nincsfile);
                            if(nincsfile)
                                goto nincsfile;
                            olvassálsokat.Mindentkiirfejléc(switch_on,keresTank);
                            break;
                        }
                        case 2:
                        {
                            Olvasgató olvassálsokat = new Olvasgató(ref nincsfile);
                            if(nincsfile)
                                goto nincsfile;
                                Console.Clear();
                                Console.Write("a keresett harckocsi pontos neve: ");
                                keresTank = Console.ReadLine();
                                olvassálsokat.Mindentkiirfejléc(switch_on,keresTank);
                            break;
                        }
                        case 3:

                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nez nem volt opció :mérges_fej:");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            nemmehettovább = true;
                            break;
                    }
                }
            } while(nemmehettovább);
        }
        private static void Main(string[] args)
        {
            bool whileosvaltozo = true;
            while (whileosvaltozo)
            {
                byte switchertek = 0;
                bool nemmehettovább;

                do
                {
                    nemmehettovább = false;
                    Console.Clear();
                    Console.WriteLine("dancikamoimod tm");
                    Console.WriteLine("\n1 - a tárolt adatok megjelenítése");
                    Console.WriteLine("2 - új adat bevitele");
                    Console.WriteLine("3 - adatbázis törlése");
                    Console.WriteLine("0 - kilépés");
                    Console.WriteLine("\nírj egy számot! :komoly_fej: \n. . .");
                        try
                        {
                            switchertek = Convert.ToByte(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ilyet ne írj ide >:O");
                        Console.ForegroundColor = ConsoleColor.White;
                        nemmehettovább = true;
                            Console.ReadLine();
                        }
                } while (nemmehettovább);

                switch (switchertek)
                {
                    case 0:
                        whileosvaltozo = false;
                        break;
                    case 1:
                        {
                            Olvasó(nemmehettovább);
                        }
                        break;
                    case 2:
                        {
                            Irogató anyatevagyaz = new Irogató(false);
                            anyatevagyaz.Ujadatbe();
                            break;
                        }
                    case 3:
                    {
                        Irogató törlő = new Irogató(false);
                        törlő.Törlés();
                        break;
                    }


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nez nem volt opció :mérges_fej:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
