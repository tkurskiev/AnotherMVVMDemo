using System;
using System.ComponentModel;

namespace AnotherMVVMDemo
{
    public class StudentModel
    {
    }

    public class Student : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                //if (firstName != value)
                //    firstName = value;

                // Другой вариант того, что закомменчено выше
                if (firstName == value)
                    return;
                firstName = value;
                RaisePropertyChanged(nameof(FirstName));  // Обрати внимание на nameof
                //  БЫЛО ТАК: RaisePropertyChanged("FirstName"); если как выше, то свойство можно легко переименовать и логика продолжит работать
                RaisePropertyChanged(nameof(FullName));   
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName != value)
                    lastName = value;
                RaisePropertyChanged(nameof(LastName));
                RaisePropertyChanged(nameof(FullName));
            }
        }

        public string FullName
        {
            get { return firstName + " " + lastName; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(property));
            //}

            // This is the same as the above
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        
    }
}
