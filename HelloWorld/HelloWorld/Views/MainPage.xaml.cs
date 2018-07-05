using HelloWorld.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            if (Device.RuntimePlatform != Device.iOS)
            {
                // NavigationPage.SetHasBackButton(this, false);
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }

        public void ButtonClicked(object sender, ClickedEventArgs e)
        {
            // label.Text = "Ich wurde geklickt!";
            Navigation.PushAsync(new WebBrowser());
        }

        public void ListClicked(object sender, ClickedEventArgs e)
        {
            Navigation.PushAsync(new Persons());
        }

	    private void BigListClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new PersonsWithAgeView());
        }
	}
}
