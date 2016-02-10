using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Harjoitus4_KonsoliXML
{
    class Program
    {
        static void ReadWorkersFromXML(string filu) {
            // Tutkitaan löytyykö tiedosto
            if (System.IO.File.Exists(filu)) {
                // Luetaan koko XML-tiedosto XmlDocument-olioon
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(filu);

                // XPath kyselykkä haetaan halutut elementit
                XmlNodeList xnl = xmldoc.SelectNodes("/tyontekijat/tyontekija");
                XmlNodeList xnl2;
                XmlNode xn; // Edustaa yksittäistä nodea xml dokumentissa
                XmlNode xn2;

                Console.WriteLine(String.Format("Tiedostosta {0} löytyi {1} työntekijää:", filu, xnl.Count));

                for (int i = 0; i < xnl.Count; i++) {
                    xn = xnl.Item(i);

                    // Listataaan (näytetään) sisältö kokonaisuudessaan
                    Console.WriteLine(xn.InnerText);

                    // Haetaan kaikki noodin ja näytetään ne
                    xnl2 = xn.ChildNodes;
                    for (int j = 0; j < xnl2.Count; j++) {
                        xn2 = xnl2.Item(j);
                        Console.WriteLine(xn2.InnerText);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            ReadWorkersFromXML("d:\\Työntekijät2013.xml");
        }
    }
}
