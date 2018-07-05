using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PerpetualEngine.Storage;
using Persons3.API;
using Persons3.Messages;
using Persons3.Models;
using Prism.Events;

namespace Persons3.ViewModels
{
    public class PersonsViewModel : BaseModel
    {
        private readonly IEventAggregator eventAggregator;
        private readonly SimpleStorage storage;

        public ObservableCollection<Person> Persons { get; set; }

        public bool HasData => Persons != null && Persons.Count > 0;

        public bool HasNoData => !HasData;

        public int AccessCount
        {
            get => storage.Get<int>("count", 0);
            set => storage.Put<int>("count", value);
        }

        public PersonsViewModel(IPersonHandler personHandler, IEventAggregator eventAggregator)
        {
            // Initialisieren / Referenzieren
            this.storage = SimpleStorage.EditGroup("data");

            // Zugriffszähler erhöhen
            AccessCount++;

            // Registrieren des Handlers
            this.eventAggregator = eventAggregator;

            // Reagieren, wenn die PersonsLoadeMessage eintritt
            eventAggregator.GetEvent<PersonsLoadedMessage>().Subscribe(HandlePersonsLoaded());

            // Publizieren der LoadPersonsMessage-Nachricht
            eventAggregator.GetEvent<LoadPersonsMessage>().Publish();
        }

        /// <summary>
        /// Wird eingebunden, wenn Personen geladen worden sind
        /// </summary>
        private Action<List<Person>> HandlePersonsLoaded()
        {
            return persons =>
            {
                // Auf dem UI-Thread ausführen
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    // Geladene Daten zuweisen
                    Persons = new ObservableCollection<Person>(persons);
                    OnPropertyChanged("Persons");
                    OnPropertyChanged("HasData");
                    OnPropertyChanged("HasNoData");
                });
            };
        }
    }
}
