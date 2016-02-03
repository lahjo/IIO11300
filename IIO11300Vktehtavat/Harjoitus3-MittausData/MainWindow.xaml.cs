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
using JAMK.IT.IIO11300;

namespace Harjoitus3_MittausData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Luodaan kokoelma mittaus-olioille
        List<MittausData> mitatut;

        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff() {
            // Omat ikkunaan liittyvät alustukset
            txtToday.Text = DateTime.Today.ToShortDateString();
            mitatut = new List<MittausData>();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            // Luodaan uusi mittausdata olia ja näytetään se käyttäjälle
            MittausData md = new MittausData(txtClock.Text, txtData.Text);
            //lbData.Items.Add(md); // Alkuperäinen tapa

            // Lisätään mittaus-olio kokoelmaan
            mitatut.Add(md);
            ApllyChanges();
        }

        private void ApllyChanges() {
            // Päivitetään UI vastaamaan kokoelma tietoja
            lbData.ItemsSource = null;
            lbData.ItemsSource = mitatut;
        }

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            // ToDo kutsu BL:n tallennusmetodia
            try
            {
                MittausData.SaveDataToFile(mitatut, txtFileName.Text);
                MessageBox.Show("Tiedot on tallennettu tiedostoon " + txtFileName.Text);
            }   
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetFromFile_Click(object sender, RoutedEventArgs e)
        {
            // Luetaan data käyttäjän antamasta tiedostosta
            try
            {
                mitatut = null;
                mitatut = MittausData.ReadDataFromFile(txtFileName.Text);
                ApllyChanges();
                MessageBox.Show("Tiedot on luettu tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveToXML_Click(object sender, RoutedEventArgs e)
        {
            // Serialisoidaan XML:ksi
            JAMK.IT.IIO11300.Serialisointi.SerialisoiXml(@"d:\testi.xml", mitatut);
        }
    }
}
