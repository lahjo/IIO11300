using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Harjoitus4_WPFXml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XElement xe;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetXml_Click(object sender, RoutedEventArgs e)
        {
            // Ladataan xml-tiedosto ja asetetaan se DataGridin data context:ksi
            try
            {
                xe = XElement.Load(GetFileName());
                dgData.DataContext = xe.Elements("tyontekija");

                // Lasketaan työntekijöiden määrä ja palkkasumma ja näytetään ne käyttäjälle
                int lkm = 0;
                lkm = xe.Elements().Count();
                tbMessage.Text = string.Format("Akun tehtaalla on kaikkiaan {0} työntekijää, joista vakituisia {2} palkat yhteensä {1} €", lkm, CalculateSalary(), countWorkers("vakituinen"));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private String GetFileName() {
           // return "d:\\Työntekijät2013.xml";

            return Harjoitus4_WPFXml.Properties.Settings.Default.XmlTiedosto;
        }

        private decimal CalculateSalary() {
            decimal result = 0;

            // Haetaan työntekijöiden palkat xml:stä (XElement-olioon) LINQ-kyselyllä
            var palkat = from ele in xe.Elements() select ele.Element("palkka");

            foreach (var item in palkat)
            {
                result += decimal.Parse(item.Value);
            }

            return result;
        }

        private int countWorkers(string tyosuhde) {
            // Lasketaan annetun työsuhteen mukaiset työntekijät LINQ-kyselylle
            var tyontekijat = from ele in xe.Elements() where ele.Element("tyosuhde").Value == tyosuhde select ele.Element("etunimi");

            // Palautetaan lukumäärä
            return tyontekijat.Count();
        }
    }
}
