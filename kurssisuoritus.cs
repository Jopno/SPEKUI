using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speku
{
     public class kurssisuoritus
    {
        public int KurssisuoritusID { get; set; }
        public Henkilo henkilo { get; set; }
        public Kurssi kurssi { get; set; }
    }

    public class Kurssi
    {
        public int Kurssitun { get; set; }
        public string Kuvaus { get; set; }
    }
}
