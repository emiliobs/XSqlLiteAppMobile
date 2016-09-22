using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XSqlLiteAppMobile.Classes;

namespace XSqlLiteAppMobile.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage ()
        {
            InitializeComponent ();

            this.Padding = Device.OnPlatform(new Thickness(10,20,10,10), new Thickness(10), new Thickness(10));



            employeesListView.ItemTemplate = new DataTemplate(typeof(EmployeeCell));
            employeesListView.RowHeight = 70;

            addButton.Clicked += AddButton_Clicked;

            employeesListView.ItemSelected += EmployeesListView_ItemSelected;

        }

        private async void EmployeesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EditPage((Employee)e.SelectedItem));
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameEntry.Text))
            {
                await DisplayAlert("Error","You must enter a First Name.","Acept");
                firstNameEntry.Focus();

                return;
            }

            if (string.IsNullOrEmpty(lastNameEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a Last Name.", "Acept");
                lastNameEntry.Focus();

                return;
            }

            if (string.IsNullOrEmpty(salaryEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a Salary.", "Acept");
                salaryEntry.Focus();

                return;
            }


            InsertImployee();
        }

        private async void InsertImployee()
        {
            var employee = new Employee();

            employee.Active = activeSwitch.IsToggled;
            employee.ContractDate = contractDateDatePicker.Date;
            employee.FirstName = firstNameEntry.Text;
            employee.LastName = lastNameEntry.Text;
            employee.Salary = decimal.Parse( salaryEntry.Text);

            using (var db = new DataAccess())
            {
                db.Insert(employee);
                employeesListView.ItemsSource = db.GetList<Employee>();
            }



            //clear all text:
            activeSwitch.IsEnabled = true;
            contractDateDatePicker.Date = DateTime.Today;
            firstNameEntry.Text = string.Empty;
            lastNameEntry.Text = string.Empty;
            salaryEntry.Text = string.Empty;

            await DisplayAlert("Message", "The Employee was created ok.", "Acept");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //open the db:
            using (var db = new DataAccess())
            {
                employeesListView.ItemsSource = db.GetList<Employee>();
            }

        }

    }


}
