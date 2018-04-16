using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speku
{
     public class Tyosuoritus
    {
        public int TyosuoritusID { get; set; }
        public Henkilo henkilo { get; set; }
        public Tyo tyo { get; set; }
    }
    public class Tyo
    {
        public int TyoId { get; set; }
        public string Tyyppi { get; set; }
        public DateTime paivamaara { get; set; }
    }
}
