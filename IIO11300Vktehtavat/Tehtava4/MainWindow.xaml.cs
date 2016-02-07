using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Tehtava4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<String> kaikkipelaajat = new List<String>();
        private List<String> pelaajatnayttolista = new List<String>();
        private Pelaaja pelaaja;

        public MainWindow()
        {
            InitializeComponent();
            elementsInitialize();
        }

        private void elementsInitialize() {
           comboBox.Items.Add("Blues");
           comboBox.Items.Add("HIFK");
           comboBox.Items.Add("HPK");
           comboBox.Items.Add("Ilves");
           comboBox.Items.Add("JYP");
           comboBox.Items.Add("KalPa");
           comboBox.Items.Add("KooKoo");
           comboBox.Items.Add("Kärpät");
           comboBox.Items.Add("Lukko");
           comboBox.Items.Add("Pelicans");
           comboBox.Items.Add("SaiPa");
           comboBox.Items.Add("Sport");
           comboBox.Items.Add("Tappara");
           comboBox.Items.Add("TPS");
           comboBox.Items.Add("Ässät");
        }

        private void btnUusiPelaaja_Click(object sender, RoutedEventArgs e)
        {
            CleanText();
            txtbStatus.Text = "Uusi Pelaaja";
        }

        private void UpdateInfo() {
            pelaajatnayttolista.Clear();
            pelaaja.listboxList(kaikkipelaajat, kaikkipelaajat.Count, pelaajatnayttolista);

            listBoxPelaajat.ItemsSource = null;
            listBoxPelaajat.ItemsSource = pelaajatnayttolista;
        }

        private void CleanText()
        {
            txtEtunimi.Text = "";
            txtSukunimi.Text = "";
            txtSiirtohinta.Text = "";
            comboBox.SelectedIndex = 0;
        }

        private void btnTalletaPelaaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pelaaja = new Pelaaja(txtEtunimi.Text, txtSukunimi.Text, comboBox.Text, int.Parse(txtSiirtohinta.Text));
                if (!kaikkipelaajat.Any(str=>str.Contains(pelaaja.Kokonimi)))
                {
                    kaikkipelaajat.Add(pelaaja.AllData());
                    UpdateInfo();

                }
                else
                {
                    kaikkipelaajat.RemoveAt(pelaaja.GetPosition(kaikkipelaajat, kaikkipelaajat.Count, pelaaja.Kokonimi));
                    kaikkipelaajat.Add(pelaaja.AllData());
                    UpdateInfo();
                }

                txtbStatus.Text = "Pelaaja Tallennettu";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxPelaajat_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pelaaja.ParseData(kaikkipelaajat ,pelaaja.GetPosition(kaikkipelaajat, kaikkipelaajat.Count, listBoxPelaajat.SelectedItem.ToString()));

            CleanText();

            txtEtunimi.Text = pelaaja.Etunimi;
            txtSukunimi.Text = pelaaja.Sukunimi;
            txtSiirtohinta.Text = pelaaja.Siirtohinta.ToString();
            comboBox.SelectedIndex = comboBox.Items.IndexOf(pelaaja.Seura);
        }

        private void btnPoistaPelaaja_Click(object sender, RoutedEventArgs e)
        {
            kaikkipelaajat.RemoveAt(pelaaja.GetPosition(kaikkipelaajat, kaikkipelaajat.Count, listBoxPelaajat.SelectedItem.ToString()));
            UpdateInfo();
            txtbStatus.Text = "Pelaaja poistettu listasta";
        }

        private void btnKirjoitaPelaajat_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Liiga-Pelaajat";
            save.DefaultExt = ".txt";
            save.Filter = "Text documents (.txt)|*.txt";

            Nullable<bool> result = save.ShowDialog();

            if (result == true) {
                File.WriteAllLines(save.FileName, kaikkipelaajat.ToArray());
            }

            txtbStatus.Text = "Tiedosto tallennettu";
        }
    }
}
