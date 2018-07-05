using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonsWithAgeView : ContentPage
	{
		public PersonsWithAgeView ()
		{
			InitializeComponent ();
		}

	    private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
            // Auslösende Komponente in korrekten Typ casten
	        var listView = (ListView) sender;

            // Wenn ein Element ausgewählt ist...
	        if (listView.SelectedItem != null)
	        {
                // ...dann als PersonWithAge-instanz auffassen
	            var item = (PersonWithAge) e.SelectedItem;

                // IsChecked-Eigenschaft umkehren (=toggeln)
	            item.IsChecked = !item.IsChecked;

                // In auslösender Komponente nichts mehr ausgewählt machen
	            listView.SelectedItem = null;
	        }
	    }

	    private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        if (null != e.Item)
	        {
	            Debug.WriteLine("Element " + ((PersonWithAge) e.Item).Name + " angetatscht");
	        }
	    }
	}
}