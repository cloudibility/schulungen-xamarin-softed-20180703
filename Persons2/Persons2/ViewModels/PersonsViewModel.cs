using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Persons3.API;
using Persons3.Models;
using Prism.Events;

namespace Persons3.ViewModels
{
    public class PersonsViewModel : BaseModel
    {
        private readonly IPersonHandler personHandler;

        public ObservableCollection<Person> Persons { get; set; }

        public bool HasData => Persons != null && Persons.Count > 0;

        public bool HasNoData => !HasData;

        public PersonsViewModel(IPersonHandler personHandler)
        {
            this.personHandler = personHandler;

            Task.Run(async () =>
            {
                // Daten laden
                var persons = await personHandler.LoadPersonsAsync();

                // Auf dem UI-Thread ausführen
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    // Geladene Daten zuweisen
                    Persons = new ObservableCollection<Person>(persons);
                    OnPropertyChanged("Persons");
                    OnPropertyChanged("HasData");
                    OnPropertyChanged("HasNoData");
                });
            });
        }
    }
}
