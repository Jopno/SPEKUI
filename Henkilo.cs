using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speku
{
    public class Henkilo
    {
        public string Nimi { get; set; }
        public DateTime Syntymaaika { get; set; }
        public string Palokunta { get; set; }
        public string Tilinumero { get; set; }
        public DateTime Liittyminen { get; set; }
        public DateTime Eroaminen { get; set; }
        public string Henkilotunnus { get; set; }

        public List<Tyosuoritus> tyolista = new List<Tyosuoritus>();
        public List<kurssisuoritus> kurssilista = new List<kurssisuoritus>();
    }
}
