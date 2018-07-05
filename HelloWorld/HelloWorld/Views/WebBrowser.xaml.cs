using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebBrowser : ContentPage
	{
		public WebBrowser ()
		{
			InitializeComponent ();

            if (Device.RuntimePlatform != Device.iOS)
            {
                // NavigationPage.SetHasBackButton(this, false);
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }

        private void go_Clicked(object sender, EventArgs e)
        {
            browser.Source = address.Text;
        }
    }
}