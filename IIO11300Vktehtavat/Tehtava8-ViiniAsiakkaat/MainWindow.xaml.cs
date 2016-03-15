using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Tehtava8_ViiniAsiakkaat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<MyViewModel> temp = new ObservableCollection<MyViewModel>();
        private int laskuri;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Basic steps
                // 1) Luodaan yhteys
                string connStr = GetConnectionString();

                SqlConnection con = new SqlConnection(connStr);
                SqlDataAdapter ada = new SqlDataAdapter("SELECT lastname, firstname, address, city from vCustomers", con);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    
                    temp.Add(new MyViewModel(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()));

                }

                con.Close();

                listView.ItemsSource = temp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetConnectionString()
        {
            // Luetaan connection string App.configista
            return Tehtava8_ViiniAsiakkaat.Properties.Settings.Default.Tietokanta;
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listView.SelectedIndex >= 0) & (listView.SelectedIndex <= temp.Count))
            {
                laskuri = listView.SelectedIndex;
                SetData();
            }
        }

        private void SetData()
        {
            MyGrid.DataContext = temp[laskuri];
        }
    }

    public class MyViewModel
    {
        private string lastname, firstname, address, city;

        public String LName
        {
            set { lastname = value; }
            get { return lastname; }
        }

        public String FName {
            set{ firstname = value; }
            get { return firstname; }
        }

        

        public String addr
        {
            set { address = value; }
            get { return address; }
        }

        public String City
        {
            set { city = value; }
            get { return city; }
        }

        public MyViewModel(string lastname, string firstname, string address, string city)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.city = city;
        }
    }
}
