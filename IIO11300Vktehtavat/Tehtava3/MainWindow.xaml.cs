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

namespace Tehtava3
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

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();

            string[] fileArray = Directory.GetFiles(txtFileName.Text.ToString(), "*.txt");
            for (int i = 0; i < fileArray.Length; i++)
            {

                listBox.Items.Add(fileArray[i]);
            }


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (var output = new StreamWriter(txtFileNameEnd.Text.ToString()))
                {
                    foreach (var file in Directory.GetFiles(txtFileName.Text.ToString(), "*.txt*"))
                    {
                        using (var input = new StreamReader(file))
                        {
                            output.WriteLine(input.ReadToEnd());
                        }
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
