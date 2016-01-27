using Microsoft.Win32;
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

namespace Harjoitus1MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadMediaFile() {
            try
            {
                // Ladataan käyttäjän antama mediatiedostoa
                //string filu = @"D:\h8306\CoffeeMaker.mp4";
                string filu = txtFileName.Text;

                // Tutkitaan onko tiedostoa olemassa
                if (System.IO.File.Exists(filu))
                {
                    mediaElement.Source = new Uri(filu);
                }
                else {
                    MessageBox.Show("Tiedostoa" + filu + " ei löydy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e) {
            mediaElement.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e) {
            mediaElement.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e) {
            mediaElement.Stop();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Avataan vakio open-dialog jotta käyttäjä voi valita yhden tiedoston
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "d:\\h8306";
            dlg.Filter = "mp3 (*.mp3)|*.mp3|Media files (*.wmv)|*.wmv|All files (*.*)|*.*";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true) {
                txtFileName.Text = dlg.FileName;
                LoadMediaFile();
            }
        }
    }
}
