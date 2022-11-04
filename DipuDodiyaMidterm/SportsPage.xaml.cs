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

namespace DipuDodiyaMidterm
{
    /// <summary>
    /// Interaction logic for SportsPage.xaml
    /// </summary>
    public partial class SportsPage : Window
    {
        // generic list of persons and sports
        private List<Person> persons;
        private List<SportsTeam> sport;
        public SportsPage()
        {
            InitializeComponent();

            //adding data to the list
            sport = new List<SportsTeam>()
            {
                new SportsTeam(0, "Priya", "Sampura", "ppatel1@gmail.com",22, "1st December 1999", 0, "BaseBall", "Kansas City"),
                new SportsTeam(1, "Yukta", "Delvada", "ypatel2@gmail.com", 22, "10th November 1999", 1, "Cricket","Ahemdabad City " ),
                new SportsTeam(2, "Nancy", "Sarbhon", "npatel3@gmail.com",22,  "14th June 2000", 2, "Table Tennis", "Mumbai City"),
                new SportsTeam(3, "Riya", "Ten", "rpatel4@gmail.com",22,  "9th September 1999", 3,"Badminton", "Delhi City" ),
                new SportsTeam(4, "Kinal", "Bardoli", "kpatel5@gmail.com", 22,"28th March 2000", 4, "Hockey", "Surat City"),

            };
        }

        internal void open()
        {
            throw new NotImplementedException();
        }

        //Clikc event for exit
        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit the App ?", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Stop);

            if (result == MessageBoxResult.OK)
            {
                Close();
            }
        }

        //List display when window loads
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
        }

        //to refresh the list
        private void RefreshListBox()
        {
            // using linq to get names from generic collection
            var names = from per in sport
                        select per.Name;


            // setting name to show in the ListBox
            lstSports.ItemsSource = names;
        }

        private void lstSportsPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSports.SelectedItem != null)
            {
                // finding selected person
                var selectedPer = (from per in sport
                                   where per.Id == lstSports.SelectedIndex
                                   select per).FirstOrDefault();

                // to display the perrson information in text boxes
                txtId.Text = selectedPer.Id.ToString();
                txtPersonID.Text = selectedPer.PersonId.ToString();
                txtTeam.Text = selectedPer.SportTeam;
                txtCity.Text = selectedPer.City;





            }
        }

       
        private void lstPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstPersons.SelectedItem != null)
            {
                
                var selectedPer = (from per in persons
                                   where per.PersonId == lstPersons.SelectedIndex
                                   select per).FirstOrDefault();

                
            }
        }

        //insert click event
        private void mnuIns_Click(object sender, RoutedEventArgs e)
        {

            //to insert data in the list
            SportsTeam newPer = new SportsTeam(lstPersons.Items.Count, txtName.Text, txtAddress.Text, txtEmail.Text, int.Parse(txtAge.Text), txtBirthday.Text, lstSports.Items.Count, txtTeam.Text, txtCity.Text);
            sport.Add(newPer);

            //datavalidation
            if (String.IsNullOrEmpty(txtTeam.Text) || String.IsNullOrEmpty(txtCity.Text) )
            {
                MessageBox.Show("Textbox cannot be empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                RefreshListBox();
            }

        }

        //update click event
        private void mnuUp_Click(object sender, RoutedEventArgs e)
        {
            if (lstSports.SelectedItem != null)
            {

                //to update data in the list
                var selectedPer = (from per in sport
                                   where per.Id == lstSports.SelectedIndex
                                   select per).FirstOrDefault();

                selectedPer.SportTeam = txtTeam.Text;
                selectedPer.City = txtCity.Text;

                //datavalidation
                if (String.IsNullOrEmpty(txtTeam.Text) || String.IsNullOrEmpty(txtCity.Text))
                {
                    MessageBox.Show("Textbox cannot be empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    var result = MessageBox.Show("Do you want to Update the List ?", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Stop);

                    if (result == MessageBoxResult.OK)
                    {
                        RefreshListBox();
                    }
                }


            }
        }

        //click event to delete item
        private void mnuDel_Click(object sender, RoutedEventArgs e)
        {
            if (lstSports.SelectedItem != null)
            {
                var selectedPer = (from per in sport
                                   where per.Id == lstSports.SelectedIndex
                                   select per).FirstOrDefault();

                sport.Remove(selectedPer);
                txtId.Text =  txtTeam.Text = txtCity.Text = " ";

                //to update data
                for (int i = 0; i < sport.Count; i++)
                    sport[i].Id = i;

                var result = MessageBox.Show("Do you want to delete this record ?", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Stop);

                if (result == MessageBoxResult.OK)
                {
                    RefreshListBox();
                }

            }
        }

        //click event to help 
        private void MenuItem_Click_Help(object sender, RoutedEventArgs e)
        {
            AboutUsPage win1 = new AboutUsPage();

            win1.Show();
        }


    
    }
}
