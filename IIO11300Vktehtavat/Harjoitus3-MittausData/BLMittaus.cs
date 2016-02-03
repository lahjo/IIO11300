using System;
using System.Collections.Generic;
using System.IO;
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

        public string DataMuoto {
            get { return kello + ";" + mittaus; }
        }

        // Ylikirjoitetaan ToString
        public override string ToString()
        {
            //return base.ToString();
            return kello + "=" + mittaus;
        }

        #region METHODS

        public static void SaveDataToFile(List<MittausData> dataa, string filu) {
            // Kirjoitetaan data tiedostoon, jos tiedosto on jo olemassa litetään se olemassaolevaan
            try
            {
                // Tutkitaan onko tiedosto olemassa
                if (!System.IO.File.Exists(filu))
                {
                    // Luodaan uusi
                    using (StreamWriter sw = File.CreateText(filu))
                    {
                        // Käydään kokoelma läpi ja kirjoitetaan kukin mittausdata omalle riville
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
                else {
                    // Lisätään olemassaolevaan tiedostoon
                    using (StreamWriter sw = File.AppendText(filu)) {
                        foreach (var item in dataa)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<MittausData> ReadDataFromFile(string filu) {
            // Luetaan käyttäjän antamasta tiedostosta tekstirivejä ja muutetaan ne mittausdataksi
            try
            {
                if (File.Exists(filu))
                {
                    using (StreamReader sr = File.OpenText(filu))
                    {
                        //Luetaan rivi kerrallaan tiedostoa
                        MittausData md;
                        List<MittausData> luetut = new List<MittausData>();
                        string rivi = "";

                        while ((rivi = sr.ReadLine()) != null) {
                            // Tutkitaan löytyykö sovittu erotinmerkki ( ; ) --> etupuolella on kellonaika ja jälkeen on mittausarvo 
                            if ((rivi.Length > 3) && rivi.Contains(";")) {
                                string[] split = rivi.Split(new char[] { ';' });

                                // Luodaan tekstinpätkistä olio
                                md = new MittausData(split[0], split[1]);
                                luetut.Add(md);
                            }
                        }

                        return luetut;
                    }
                }
                else {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
