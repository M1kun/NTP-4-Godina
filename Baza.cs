using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Baza
    {
        public static Dictionary<int, Knjiga> knjige = new Dictionary<int, Knjiga>();
        public static Dictionary<int, Clan> clanovi = new Dictionary<int, Clan>();
    }
}
