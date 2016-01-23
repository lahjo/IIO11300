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

namespace Tehtävä2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            component();
                
        }

        private void component() {
            comboBox.Items.Add("SuomiLotto");
            comboBox.Items.Add("VikingLotto");
            comboBox.Items.Add("Eurojackpot");

            comboBox.SelectedItem = "SuomiLotto";
        }

        private void draw_Click(object sender, RoutedEventArgs e) {
            try
            {
                int rounds = int.Parse(roundsNum.Text);

                BLLotto lotto = new BLLotto();

                if (comboBox.SelectedItem == "SuomiLotto") {
                    for (int roundsLimit = 0; roundsLimit < rounds; roundsLimit++) {
                        listBox.Items.Add(lotto.SuomiLotto());
                    }
                } else if(comboBox.SelectedItem == "VikingLotto") {
                    for (int roundsLimit = 0; roundsLimit < rounds; roundsLimit++)
                    {
                        listBox.Items.Add(lotto.VikingLotto());
                    }
                } else if (comboBox.SelectedItem == "Eurojackpot") {
                    for (int roundsLimit = 0; roundsLimit < rounds; roundsLimit++)
                    {
                        listBox.Items.Add(lotto.Eurojackpot());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }
    }
}
