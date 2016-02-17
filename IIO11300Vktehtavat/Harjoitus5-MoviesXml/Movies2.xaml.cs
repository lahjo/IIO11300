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
using System.Windows.Shapes;
using System.Xml;

namespace Harjoitus5_MoviesXml
{
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window
    {
        public Movies2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Tallennetaan muuttunut tieto xml tiedostoon
            try
            {
                string filu = xdpMovies.Source.LocalPath;
                xdpMovies.Document.Save(filu);
            }
            catch (Exception ex)   
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            if(lbMovies.SelectedIndex > -1) {
            // Lisätään xmlDocumenttiin uusi elementti
            lbMovies.SelectedIndex = -1;
            }
            else
            {
                // Lisätään uusi node
                string filu = xdpMovies.Source.LocalPath;

                // Viittaus xml documenttiin ja sen juurielementtiin
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");

                // Luodaan uusi node
                XmlNode newMovie = doc.CreateElement("Movie");

                // Lisätään atribuutit elokuvan nimelle
                XmlAttribute attr = doc.CreateAttribute("Name");
                attr.Value = txtName.Text;
                newMovie.Attributes.Append(attr);

                // Lisätään atribuutit elokuvan ohjaajalle
                XmlAttribute attr2 = doc.CreateAttribute("Director");
                attr2.Value = txtDirector.Text;
                newMovie.Attributes.Append(attr2);

                // Lisätään atribuutit elokuvan Maalle
                XmlAttribute attr3 = doc.CreateAttribute("Country");
                attr3.Value = txtCountry.Text;
                newMovie.Attributes.Append(attr3);

                root.AppendChild(newMovie);

                // Tallennetaan tiedostoon
                xdpMovies.Document.Save(filu);

            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Poistetaan xmlDocumentista valittu elementti
        }
    }
}
