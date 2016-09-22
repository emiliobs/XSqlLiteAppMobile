using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XSqlLiteAppMobile.Classes;

namespace XSqlLiteAppMobile.Pages
{
    public partial class EditPage : ContentPage
    {
        private Employee employee;

        public EditPage (Employee employee)
        {
            InitializeComponent ();


            this.employee = employee;

            this.Padding = Device.OnPlatform(new Thickness(10,20,10,10), new Thickness(10), new Thickness(10));


            firstNameEntry.Text = employee.FirstName;
            lastNameEntry.Text = employee.LastName;
            salaryEntry.Text = employee.Salary.ToString();
            activeSwitch.IsToggled = employee.Active;
            contractDateDatePicker.Date = employee.ContractDate;


            updateButton.Clicked += UpdateButton_Clicked;
            deleteButton.Clicked += DeleteButton_Clicked;


        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Confirm","Are you sure to delete the Record?","Yes","No");

            if (!response)
            {
                return;
            }

            using (var db = new DataAccess())
            {
                db.Delete(employee);
            }

            await DisplayAlert("Message","The record was deleted.","Acept");
            await Navigation.PopAsync();

        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameEntry.Text))
            {
                await DisplayAlert("Error","You must enter a First Name","Acept");
                firstNameEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(lastNameEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a Last Name", "Acept");
                lastNameEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(salaryEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a Salary ", "Acept");
                salaryEntry.Focus();
                return;
            }

            employee.Active = activeSwitch.IsToggled;
            employee.ContractDate = contractDateDatePicker.Date;
            employee.FirstName = firstNameEntry.Text;
            employee.LastName = lastNameEntry.Text;
            employee.Salary = decimal.Parse( salaryEntry.Text);

            using (var db = new DataAccess())
            {
                db.Update(employee);
            }


            await DisplayAlert("Message","The records was Update.","Acept");
            await Navigation.PopAsync();


        }
    }
}
