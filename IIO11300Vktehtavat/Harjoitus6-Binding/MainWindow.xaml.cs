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

namespace Harjoitus6_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HockeyLeague smliiga;
        List<HockeyTeam> joukkueet;
        int clicked = 0;

        public MainWindow()
        {
            InitializeComponent();
            FillMyComboBox();
            smliiga = new HockeyLeague();
            joukkueet = smliiga.GetTeams();
        }

        private void btnSetUser_Click(object sender, RoutedEventArgs e)
        {
            // Luetaan App.Configista UserName-asetus
            txtUsername.Text = "Terve käyttäjä: " + Harjoitus6_Binding.Properties.Settings.Default.UserName;
        }

        private void FillMyComboBox() {
            cbCourses2.Items.Add("IIO12110 Ohjelmistotuotanto");
            cbCourses2.Items.Add("Ruotsi");
        }

        private void btnForword_Click(object sender, RoutedEventArgs e)
        {
            clicked++;
            myGrid.DataContext = joukkueet[clicked];
        }

        private void btnBackword_Click(object sender, RoutedEventArgs e)
        {
            clicked--;
            myGrid.DataContext = joukkueet[clicked];
        }

        private void btnBind_Click_1(object sender, RoutedEventArgs e)
        {
            myGrid.DataContext = joukkueet;
        }
    }
}
