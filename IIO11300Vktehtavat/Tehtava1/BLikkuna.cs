using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class IkkunaVE0 {
        // Tehdään public, ÄLÄ käytä! Edustaa "huonoa" ohjelmointitapaa
        public double leveys, korkeus;

        public double LaskePintaAla() {
            return leveys * korkeus;
        }
    }

    public class Ikkuna {
        // property = ominaisuus
        // Parempi tap on avata "hallitusti" olio ominaisuuksien kautta

        private double korkeus;

        public double Korkeus {
            get { return korkeus; }
            set { korkeus = value; }
        }

        private double leveys;

        public double Leveys {
            get { return leveys; }
            set { leveys = value; }
        }

        // read-only tyyppinen property
        public double PintaAla {
            get { /*return korkeus * leveys;*/ return LaskeIPintaAla(); }
        }

        // Metodit
        public double LaskePintaAla() {
            //return korkeus * leveys;
            return LaskeIPintaAla();
        }

        private double LaskeIPintaAla() {
            return korkeus * leveys;
        }
    }
}
