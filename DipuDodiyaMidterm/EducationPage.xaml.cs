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
    /// Interaction logic for EducationPage.xaml
    /// </summary>
    public partial class EducationPage : Window
    {
        // generic list of persons and educations
        private List<Person> persons;
            private List<Education> educate;
            public EducationPage()
            {
                InitializeComponent();

            //adding data to the list
            educate = new List<Education>()
            {
                new Education(0, "Priya", "Sampura", "ppatel1@gmail.com",22, "1st December 1999", 0, "Math", 88, "Good "),
                new Education(1, "Yukta", "Delvada", "ypatel2@gmail.com", 22, "10th November 1999", 1, "Computer", 97, "Excellent" ),
                new Education(2, "Nancy", "Sarbhon", "npatel3@gmail.com",22,  "14th June 2000", 2, "English", 96,"Excellent"),
                new Education(3, "Riya", "Ten", "rpatel4@gmail.com", 22, "9th September 1999", 3,"Hindi", 86,  "Good" ),
                new Education(4, "Kinal", "Bardoli", "kpatel5@gmail.com", 22, "28th March 2000", 4, "Social Science", 87,  "Good"),

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
            var names = from per in educate
                            select per.Name;


            // setting name to show in the ListBox
            lstEducation.ItemsSource = names;
            }

            private void lstSportsPage_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            if (lstEducation.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }

            else
                if (lstEducation.SelectedItem != null)
                {
                // finding selected person
                var selectedPer = (from per in educate
                                       where per.Id == lstEducation.SelectedIndex
                                       select per).FirstOrDefault();

                // to display the person information in text boxes
                txtId.Text = selectedPer.Id.ToString();
                txtPersonID.Text = selectedPer.PersonId.ToString();
                txtGrade.Text = selectedPer.CourseGrade.ToString();
                    txtCourse.Text = selectedPer.CourseName;
                    txtComments.Text = selectedPer.Comments;





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

            //datavalidation
            int v;
                if (!int.TryParse(txtGrade.Text, out v))
                {
                    MessageBox.Show("Please Enter the correct integer value in Textbox for Course Grade", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                //to insert data in the list

                Education newPer = new Education(lstPersons.Items.Count, txtName.Text, txtAddress.Text, txtEmail.Text, int.Parse(txtAge.Text), txtBirthday.Text, lstEducation.Items.Count, txtCourse.Text, int.Parse(txtGrade.Text), txtComments.Text);
                    educate.Add(newPer);

                    if (String.IsNullOrEmpty(txtCourse.Text) || String.IsNullOrEmpty(txtComments.Text))
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
            if (lstEducation.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }

            else
            if (lstEducation.SelectedItem != null)
            {
            //datavalidation
            int v;
                if (!int.TryParse(txtGrade.Text, out v))
                {
                    MessageBox.Show("Please Enter the correct integer value in Textbox for Course Grade", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                //to update data in the list
                var selectedPer = (from per in educate
                                        where per.Id == lstEducation.SelectedIndex
                                        select per).FirstOrDefault();

                    selectedPer.CourseGrade = int.Parse(txtGrade.Text);
                    selectedPer.CourseName = txtCourse.Text;
                    selectedPer.Comments = txtComments.Text;

                    if (String.IsNullOrEmpty(txtCourse.Text) || String.IsNullOrEmpty(txtComments.Text))
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
            if (lstEducation.SelectedItem == null)
            {
                MessageBox.Show("Please Select the Name from List", "Error", MessageBoxButton.OK);

            }

            else
            if (lstEducation.SelectedItem != null)
            {
                var selectedPer = (from per in educate
                                    where per.Id == lstEducation.SelectedIndex
                                    select per).FirstOrDefault();

            educate.Remove(selectedPer);
                txtId.Text = txtPersonID.Text = txtCourse.Text = txtComments.Text = " ";

            //to update data
            for (int i = 0; i < educate.Count; i++)
                educate[i].Id = i;

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

    
