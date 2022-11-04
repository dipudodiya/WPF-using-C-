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

namespace DipuDodiyaMidterm
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

        private void PersonPageButton_Click(object sender, RoutedEventArgs e)
        {
            PersonsPage win1 = new PersonsPage();

            win1.Show();
        }

        private void SportPageButton_Click(object sender, RoutedEventArgs e)
        {
            SportsPage win1 = new SportsPage();

            win1.Show();
        }

        private void PersonalityPageButton_Click(object sender, RoutedEventArgs e)
        {
            PersonalityPage win1 = new PersonalityPage();

            win1.Show();
        }

        private void EducationPageButton_Click(object sender, RoutedEventArgs e)
        {
            EducationPage win1 = new EducationPage();

            win1.Show();
        }

        

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit the App ?", "Alert" ,MessageBoxButton.OKCancel , MessageBoxImage.Stop);

            if(result == MessageBoxResult.OK)
            {
                Close();
            }
        }

       

        private void mnuIns_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Applicable on Home Page. Please Select Correct Page");
        }

        private void mnuUp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Applicable on Home Page. Please Select Correct Page");
        }

        private void mnuDel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Applicable on Home Page. Please Select Correct Page");
        }

        private void MenuItem_Click_Help(object sender, RoutedEventArgs e)
        {
            AboutUsPage win1 = new AboutUsPage();

            win1.Show();
        }
    }
}
