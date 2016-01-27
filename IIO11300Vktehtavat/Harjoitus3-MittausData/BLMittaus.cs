using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public class MittausData {
        private string kello;

        public string Kello
        {
            get { return kello; }
            set { kello = value; }
        }

        private string mittaus;

        public string Mittaus
        {
            get { return Mittaus; }
            set { Mittaus = value; }
        }

        #region CONSTRUCTORS
        // Luokalle tehdään kaksi konstruktoria
        public MittausData() {
            kello = "0:00";
            mittaus = "empty";
        }

        public MittausData(string klo, string mdata) {
            this.kello = klo;
            this.mittaus = mdata;
        }
        #endregion

        // Ylikirjoitetaan ToString
        public override string ToString()
        {
            //return base.ToString();
            return kello + "=" + mittaus;
        }
    }
}
