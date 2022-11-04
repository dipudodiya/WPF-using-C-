using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for PersonsPage.xaml
    /// </summary>
    public partial class PersonsPage : Window
    {
        // generic list of persons
        private List<Person> persons;
        public PersonsPage()
        {
            InitializeComponent();

            //adding data to the list
            persons = new List<Person>()
            {
                new Person(0, "Priya", "Sampura", "ppatel1@gmail.com",22, "1st December 1999"),
                new Person(1, "Yukta", "Delvada", "ypatel2@gmail.com", 22, "10th November 1999"),
                new Person(2, "Nancy", "Sarbhon", "npatel3@gmail.com", 22, "14th June 2000"),
                new Person(3, "Riya", "Ten", "rpatel4@gmail.com",22,   "9th September 1999"),
                new Person(4, "Kinal", "Bardoli", "kpatel5@gmail.com",22, "28th March 2000"),

            };
        }

        internal void open()
        {
            throw new NotImplementedException();
        }
        
        //Click event for exit
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
            var names = from per in persons
                        select per.Name;

            // setting name to show in the ListBox
            lstPersons.ItemsSource = names;
        }

        
        private void lstPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lstPersons.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }

            else
            if (lstPersons.SelectedItem != null)
            {
                // finding selected person
                var selectedPer = (from per in persons
                                   where per.PersonId == lstPersons.SelectedIndex
                                   select per).FirstOrDefault();

                // to display the perrson information in text boxes
                txtId.Text = selectedPer.PersonId.ToString();
                txtName.Text = selectedPer.Name;
                txtAddress.Text = selectedPer.Address;
                txtEmail.Text = selectedPer.Email;
               txtAge.Text = selectedPer.Age.ToString();
                txtBirthday.Text = selectedPer.Birthday;


            }
        }

        //insert click event
        private void mnuIns_Click(object sender, RoutedEventArgs e)
        {

           

                //datavalidation
                int v;
            if (!int.TryParse(txtAge.Text, out v))
            {
                MessageBox.Show("Please Enter the correct integer value in Textbox for Age", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //to insert data in the list
                Person newPer = new Person(lstPersons.Items.Count, txtName.Text, txtAddress.Text, txtEmail.Text, int.Parse(txtAge.Text), txtBirthday.Text);
                persons.Add(newPer);

                if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtBirthday.Text))
                {
                    MessageBox.Show("Textbox cannot be empty", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    RefreshListBox();
                }
            }
        }

        //update click event
        private void mnuUp_Click(object sender, RoutedEventArgs e)
        {
            if (lstPersons.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }

            else
            if (lstPersons.SelectedItem != null)
            {
                //datavalidation
                int v;
                if (!int.TryParse(txtAge.Text, out v))
                {
                    MessageBox.Show("Please Enter the correct integer value in Textbox for Age", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //to update data in the list
                    var selectedPer = (from per in persons
                                       where per.PersonId == lstPersons.SelectedIndex
                                       select per).FirstOrDefault();

                    selectedPer.Name = txtName.Text;
                    selectedPer.Address = txtAddress.Text;
                    selectedPer.Email = txtEmail.Text;
                    selectedPer.Age = int.Parse(txtAge.Text);
                    selectedPer.Birthday = txtBirthday.Text;



                    if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtAddress.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtBirthday.Text))
                    {
                        MessageBox.Show("Please Enter the correct value in Textbox", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (lstPersons.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }

            else
            if (lstPersons.SelectedItem != null)
            {
                var selectedPer = (from per in persons
                                   where per.PersonId == lstPersons.SelectedIndex
                                   select per).FirstOrDefault();

                persons.Remove(selectedPer);
                txtId.Text = txtName.Text = txtAddress.Text = txtEmail.Text = txtAge.Text = txtBirthday.Text = " ";

                //to update data
                for (int i = 0; i < persons.Count; i++)
                    persons[i].PersonId = i;

               
                    var result = MessageBox.Show("Do you want to Delete the List ?", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Stop);

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
