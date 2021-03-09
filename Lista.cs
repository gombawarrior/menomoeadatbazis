using System.Collections.Generic;

namespace DuncikaMoexd
{
    class Lista
    {
        public struct Adatosstrukt
        {
            public string tanknev;
            public ulong elsomark, masodikmark, harmadikmark,száz;
        }
        public List<Adatosstrukt> menőlista = new List<Adatosstrukt>();
    }
}
