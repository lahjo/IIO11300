/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 13.1.2016
* Authors: Joonas Lähteinen, Esa Salmikangas
*/using System;
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

namespace Tehtava1
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try
            {
                double result;

                double height = double.Parse(txtHeight.Text);
                double widht = double.Parse(txtWidht.Text);
                double karmWidht = double.Parse(txtKarmWidht.Text);

                BusinessLogicWindow bs = new BusinessLogicWindow();

                result = bs.CalculatePerimeter(height, widht);
                double windowsarea = result - ((height - 2*karmWidht) * (widht - 2*karmWidht));
                b1.Text = windowsarea.ToString();

                double karmarea = result - windowsarea;
                a1.Text = karmarea.ToString();

                double karmpiiri = widht + height + widht + height;
                c1.Text = karmpiiri.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
                
            }
        }
  }

  public class BusinessLogicWindow
    {
    /// <summary>
    /// CalculatePerimeter calculates the perimeter of a window
    /// </summary>
    public double CalculatePerimeter(double widht, double height)
        {
            //throw new System.NotImplementedException();
            double area = widht * height;

            return area;
        }
    }
}
