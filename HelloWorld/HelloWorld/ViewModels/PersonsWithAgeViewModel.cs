using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class PersonsWithAgeViewModel : BaseModel
    {

        private string newPersonName;
        private int newPersonAge;
        private bool showInputForm;

        public ObservableCollection<PersonWithAge> Persons { get; set; }

        public string NewPersonName
        {
            get { return newPersonName; }
            set
            {
                newPersonName = value; 
                OnPropertyChanged();
            }
        }

        public int NewPersonAge
        {
            get { return newPersonAge; }
            set
            {
                newPersonAge = value;
                OnPropertyChanged();
            }
        }

        public bool ShowInputForm
        {
            get { return showInputForm; }
            set
            {
                showInputForm = value;
                OnPropertyChanged();
            }
        }

        public Command NewCommand { get; set; }

        public Command DeleteCommand { get; set; }

        public Command AddCommand { get; set; }

        public Command CancelCommand { get; set; }

        public PersonsWithAgeViewModel()
        {
            NewCommand = new Command(() =>
            {
                ShowInputForm = true;
                NewPersonAge = 99;
                NewPersonName = string.Empty;
            });

            AddCommand = new Command(async () =>
            {
                var persons = Persons.ToList();

                if (!string.IsNullOrEmpty(NewPersonName) && NewPersonAge > 0 && NewPersonAge < 150)
                {
                    persons.Add(new PersonWithAge
                    {
                        Name = NewPersonName,
                        Age = NewPersonAge,
                        IsChecked = false
                    });

                    ShowInputForm = false;
                    
                    Persons = new ObservableCollection<PersonWithAge>(persons);
                    OnPropertyChanged("Persons");
                }
                else
                {
                    // Don't try this at home!
                    if (Application.Current != null && Application.Current.MainPage != null)
                        await Application.Current.MainPage.DisplayAlert(
                            "Korrektur nötig!", "Name oder Alter passen nicht!",
                            "Aha");
                }
            });

            CancelCommand = new Command(() => ShowInputForm = false);

            DeleteCommand = new Command(() =>
            {
                // Personen, die angechecked sind, auswählen
                var personsToBeDeleted = Persons.Where(x => x.IsChecked).ToList();

                // Löschen...
                foreach (var person in personsToBeDeleted)
                {
                    Persons.Remove(person);
                }
            });

            Persons = new ObservableCollection<PersonWithAge>
            {
                new PersonWithAge
                {
                    Age = 37,
                    Name = "Klaus"
                },
                new PersonWithAge
                {
                    Age = 23,
                    Name = "Peter"
                },
                new PersonWithAge
                {
                    Age = 67,
                    Name = "Rüdiger"
                }
            };

            ShowInputForm = false;
        }

    }
}
