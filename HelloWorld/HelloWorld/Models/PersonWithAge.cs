using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    public class PersonWithAge : BaseModel
    {

        private string name;
        private int age;
        private bool isChecked;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
    }
}
