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
            LoadMediaFile();
        }

        private void LoadMediaFile() {
            try
            {
                // Ladataan käyttäjän valitsemaa mediatiedostoa
                string filu = @"D:\h8306\CoffeeMaker.mp4";

                // Tutkitaan onko tiedostoa olemassa
                if (System.IO.File.Exists(filu)) { 
                    mediaElement.Source = new Uri(filu);
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
    }
}
