using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Tehtava9_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int visible = 0;
        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void init() {
            addCustomerstpanel.Visibility = Visibility.Collapsed;
        }

        private void btnNewCustomerShow_Click(object sender, RoutedEventArgs e)
        {
            
            if(visible == 0) {
                addCustomerstpanel.Visibility = Visibility.Visible;
                visible = 1;
            } else {
                addCustomerstpanel.Visibility = Visibility.Collapsed;
                visible = 0;
            }
            
        }

        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (Enimi.Text != "" & Snimi.Text != "" & osoite.Text != "" & posnro.Text != "" & kaupunki.Text != "") {
                try
                {
                    string connStr = GetConnectionString();
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        // Avataan yhteys
                        conn.Open();

                        // 2) Tehdään SQL kysely, siitä luodaan Command-tyyppinen olio
                        string sql = string.Format("INSERT INTO customer (firstname, lastname, address, zip, city) VALUES ('{0}','{1}','{2}','{3}','{4}')", Enimi.Text, Snimi.Text, osoite.Text, posnro.Text, kaupunki.Text);
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        SqlDataReader rdr = cmd.ExecuteReader();
                        MessageBox.Show("Save Data");
                        while (rdr.Read()) {/* Wait */}

                        rdr.Close();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            } else {
                MessageBox.Show("Täytä kaikki kentät");
            }
        } 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Basic steps
                // 1) Luodaan yhteys
                string connStr = GetConnectionString();

                SqlConnection con = new SqlConnection(connStr);
                SqlDataAdapter ada = new SqlDataAdapter("SELECT id, firstname, lastname, address, zip, city from customer", con);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                GridCustomers.DataContext = dt.DefaultView;

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string GetConnectionString()
        {
            // Luetaan connection string App.configista
            return Tehtava9_CRUD.Properties.Settings.Default.Tietokanta;
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
             {

                DataRowView rowview = GridCustomers.SelectedItem as DataRowView;
                string lastname = rowview.Row[2].ToString();
                string fname = rowview.Row[1].ToString();

                MessageBoxResult m = MessageBox.Show("Haluatko varmasti poistaa " + fname + " " + lastname + ":n", "Viinikellarin asiakas", MessageBoxButton.OKCancel);
                if (m == MessageBoxResult.Cancel)
                {
                    
                }
                else if (m == MessageBoxResult.OK)
                {
                    string connStr = GetConnectionString();
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        // Avataan yhteys
                        conn.Open();

                        // 2) Tehdään SQL kysely, siitä luodaan Command-tyyppinen olio
                        string sql = string.Format("DELETE FROM customer WHERE lastname='{0}'", lastname);
                        SqlCommand cmd = new SqlCommand(sql, conn);

                        SqlDataReader rdr = cmd.ExecuteReader();
                        MessageBox.Show("Henkilö on poistettu");
                        while (rdr.Read()) { }

                        rdr.Close();
                        conn.Close();
                    }
                }
             }
             catch (Exception ex)
             {

                 MessageBox.Show(ex.Message);
             }
        }
    }
}
