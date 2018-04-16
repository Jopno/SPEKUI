using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speku
{
    public class Henkilo
    {
        public Henkilo(string nimi, DateTime syntymaika, string tilinumero, string henkilotunnus)
        {
            Nimi = nimi;
            Syntymaaika = syntymaika;
            Tilinumero = tilinumero;
            Henkilotunnus = henkilotunnus;
        }
        public string Nimi { get; set; }
        public DateTime Syntymaaika { get; set; }
        public Palokunta Palokunta { get; set; }
        public string Tilinumero { get; set; }
        public DateTime Liittyminen { get; set; }
        public DateTime Eroaminen { get; set; }
        public string Henkilotunnus { get; set; }

        public List<Tyosuoritus> tyolista = new List<Tyosuoritus>();
        public List<kurssisuoritus> kurssilista = new List<kurssisuoritus>();
    }
}
