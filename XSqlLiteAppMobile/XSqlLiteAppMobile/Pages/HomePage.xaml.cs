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

            this
                .Padding = Device.OnPlatform(new Thickness(10,20,10,10), new Thickness(10), new Thickness(10));
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
