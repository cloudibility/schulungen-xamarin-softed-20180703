using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Persons : ContentPage
	{

        public Persons ()
		{
            InitializeComponent ();

            // BindingContent = Datenkontext (von wo werden die Daten geladen) wird gesetzt!
            BindingContext = this;

            if (Device.RuntimePlatform != Device.iOS)
            {
                // NavigationPage.SetHasBackButton(this, false);
                NavigationPage.SetHasNavigationBar(this, false);
            }
		}
	}
}