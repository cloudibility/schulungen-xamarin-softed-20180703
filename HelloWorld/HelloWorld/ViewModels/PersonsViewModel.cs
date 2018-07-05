using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class PersonsViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Liste der Personen
        /// </summary>
        public ObservableCollection<string> PersonsList { get; set; }

        /// <summary>
        /// Command zum Hinzufügen einer Person
        /// </summary>
        public Command AddPersonCommand { get; private set; }

        public PersonsViewModel()
        {
            // Command initialisieren
            AddPersonCommand = new Command(() =>
            {
                PersonsList.Add("Person #" + PersonsList.Count);
            });

            var persons = new ObservableCollection<String>
            {
                "Klaus",
                "Peter",
                "Michael",
                "Rüdiger",
                "Bernd",
                "Jürgen",
                "Sebastian",
                "Mark",
                "Wolfgang",
                "Jochen",
                "Klaus",
                "Peter",
                "Michael",
                "Rüdiger",
                "Bernd",
                "Jürgen",
                "Sebastian",
                "Mark",
                "Wolfgang",
            };

            PersonsList = persons;
            OnPropertyChanged("PersonsList");
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
