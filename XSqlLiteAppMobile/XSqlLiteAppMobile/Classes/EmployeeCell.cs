using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XSqlLiteAppMobile.Classes
{
   public class EmployeeCell : ViewCell
    {

        public EmployeeCell()
        {
            var employeeIdlabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };


            employeeIdlabel.SetBinding(Label.TextProperty, new Binding("EmployeeId"));


            var fullNameLabel = new Label
            {
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            fullNameLabel.SetBinding(Label.TextProperty, new Binding("FullName"));

            var contractDateLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            contractDateLabel.SetBinding(Label.TextProperty, new Binding("ContractDate",  stringFormat:"{0:dd/MM/yyyy}"));

            var salaryLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.End,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            salaryLabel.SetBinding(Label.TextProperty, new Binding("Salary", stringFormat:"{0:C2}"));

            var activeSwich = new Switch
            {
                IsEnabled = false,
                HorizontalOptions = LayoutOptions.End
            };

            activeSwich.SetBinding(Switch.IsToggledProperty, new Binding("Active"));

            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { employeeIdlabel, fullNameLabel, activeSwich},
            };

            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {  contractDateLabel, salaryLabel, activeSwich}
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { line1, line2}
            };

        }


    }
}
