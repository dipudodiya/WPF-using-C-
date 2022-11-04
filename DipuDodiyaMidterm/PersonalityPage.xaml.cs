using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using System.Xml.Linq;

namespace DipuDodiyaMidterm
{
    /// <summary>
    /// Interaction logic for PersonalityPage.xaml
    /// </summary>
    public partial class PersonalityPage : Window
    {

        private List<Person> persons;
        private List<Personality> personality;
        public PersonalityPage()
        {
            InitializeComponent();

            //to add data into list
            personality = new List<Personality>()
            {
                new Personality(0, "Priya", "Sampura", "ppatel1@gmail.com",22, "1st December 1999", 0, 6, "Jab Tak Hai Jann", "Sharukh Kahn"),
                new Personality(1, "Yukta", "Delvada", "ypatel2@gmail.com", 22, "10th November 1999", 1,6, "Hum Dil De Chuke Sanam","Salman Khan " ),
                new Personality(2, "Nancy", "Sarbhon", "npatel3@gmail.com", 22, "14th June 2000", 2,5, "Darr", "Paresh Rawal"),
                new Personality(3, "Riya", "Ten", "rpatel4@gmail.com",22,  "9th September 1999", 3, 7,"Prem Ratan Dhan Payo", "Hritik Roshan" ),
                new Personality(4, "Kinal", "Bardoli", "kpatel5@gmail.com", 22, "28th March 2000", 4, 6, "Dil", "Akshay Kumar"),

            };
        }

        internal void open()
        {
            throw new NotImplementedException();
        }

        //click event for exit
        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to exit the App ?", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Stop);

            if (result == MessageBoxResult.OK)
            {
                Close();
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            // using linq to get names from generic collection
            var names = from per in personality
                        select per.Name;


            
            lstPersonality.ItemsSource = names;
        }

        private void lstPersonality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstPersonality.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }

            else if(lstPersonality.SelectedItem != null)
            {
                // to get the value of selected person
                var selectedPer = (from per in personality
                                   where per.Id == lstPersonality.SelectedIndex
                                   select per).FirstOrDefault();

                // to display the person information in text boxes
                txtId.Text = selectedPer.Id.ToString();
                txtPersonID.Text = selectedPer.PersonId.ToString();
                txtShoeSize.Text = selectedPer.ShoeSize.ToString();
                txtMovie.Text = selectedPer.FavouriteMovie;
                txtActor.Text = selectedPer.FavouriteActor;

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

        private void mnuIns_Click(object sender, RoutedEventArgs e)
        {
            //datavalidation
            int v;
            if (!int.TryParse(txtShoeSize.Text, out v))
            {
                MessageBox.Show("Please Enter the correct integer value in Textbox for Shoe Size", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Personality newPer = new Personality(lstPersons.Items.Count, txtName.Text, txtAddress.Text, txtEmail.Text, int.Parse(txtAge.Text), txtBirthday.Text, lstPersonality.Items.Count, int.Parse(txtShoeSize.Text), txtMovie.Text, txtActor.Text);
                personality.Add(newPer);


                if (String.IsNullOrEmpty(txtShoeSize.Text) || String.IsNullOrEmpty(txtMovie.Text) || String.IsNullOrEmpty(txtActor.Text))
                {
                    MessageBox.Show("Textbox cannot be empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    RefreshListBox();
                }
            }
        }


        private void mnuUp_Click(object sender, RoutedEventArgs e)
        {
            if (lstPersonality.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }
            else 
            if (lstPersonality.SelectedItem != null)
            {

                int v;
                if (!int.TryParse(txtShoeSize.Text, out v))
                {
                    MessageBox.Show("Please Enter the correct integer value in Textbox for Shoe Size", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {  
                    //to update data in the list
                    var selectedPer = (from per in personality
                                       where per.Id == lstPersonality.SelectedIndex
                                       select per).FirstOrDefault();
                    selectedPer.ShoeSize = int.Parse(txtShoeSize.Text);
                    selectedPer.FavouriteMovie = txtMovie.Text;
                    selectedPer.FavouriteActor = txtActor.Text;

                    if (String.IsNullOrEmpty(txtShoeSize.Text) || String.IsNullOrEmpty(txtMovie.Text) || String.IsNullOrEmpty(txtActor.Text))
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
        }

        //click event to delete item
        private void mnuDel_Click(object sender, RoutedEventArgs e)
        {
            if (lstPersonality.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }

               else if (lstPersonality.SelectedItem != null)
            {
                var selectedPer = (from per in personality
                                   where per.Id == lstPersonality.SelectedIndex
                                   select per).FirstOrDefault();

                personality.Remove(selectedPer);
                txtId.Text = txtMovie.Text = txtActor.Text = " ";

                //to update data
                for (int i = 0; i < personality.Count; i++)
                    personality[i].Id = i;

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
