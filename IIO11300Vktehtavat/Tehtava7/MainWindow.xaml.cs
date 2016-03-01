using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tehtava7
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

        private void textBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            int countChars = textBox.Text.Count();
            int countLower = Regex.Matches(textBox.Text, @"\p{Ll}").Count;
            int countUpper = Regex.Matches(textBox.Text, @"\p{Lu}").Count;
            int countOther = Regex.Matches(textBox.Text, @"\W").Count;
            int countNumber = Regex.Matches(textBox.Text, @"\d").Count;

            txtbMerkitNumber.Text = countChars.ToString();
            txtbIsotKirjaimetNumber.Text = countUpper.ToString();
            txtbPienetKirjaimetNumber.Text = countLower.ToString();
            txtbNumerotNumber.Text = countNumber.ToString();
            txtbErikoismerkitNumber.Text = countOther.ToString();

            if (countChars == 0)
            {
                Result.Text = "";
            }
            else if (countChars <= 8 )
            {
                Result.Text = "Bad";
                ColorStackPnale.Background = new SolidColorBrush(Color.FromArgb(255, 255, 125, 0));
            }
            else if (countChars > 11 && countChars < 16 && countLower != 0 && countUpper != 0 && countOther != 0 ||
                    countChars > 11 && countChars < 16 && countLower != 0 && countUpper != 0 && countNumber != 0 ||
                    countChars > 11 && countChars < 16 && countLower != 0 && countOther != 0 && countNumber != 0 ||
                    countChars > 11 && countChars < 16 && countUpper != 0 && countOther != 0 && countNumber != 0)
            {
                Result.Text = "Moderate";
                ColorStackPnale.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            }
            else if (countChars >= 16 && countLower != 0 && countUpper != 0 && countOther != 0 && countNumber != 0 )
            {
                Result.Text = "Good";
                ColorStackPnale.Background = new SolidColorBrush(Color.FromArgb(255, 125, 0, 255));
            }
            else if (countChars > 11 && countChars < 16 && countLower != 0 && countUpper != 0 ||
                     countChars > 11 && countChars < 16 && countLower != 0 && countOther != 0 ||
                     countChars > 11 && countChars < 16 && countLower != 0 && countNumber != 0 ||
                     countChars > 11 && countChars < 16 && countUpper != 0 && countOther != 0 ||
                     countChars > 11 && countChars < 16 && countUpper != 0 && countNumber != 0 ||
                     countChars > 11 && countChars < 16 && countOther != 0 && countNumber != 0)
            {
                Result.Text = "Fair";
                ColorStackPnale.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)); 
            }
        }
    }
}
