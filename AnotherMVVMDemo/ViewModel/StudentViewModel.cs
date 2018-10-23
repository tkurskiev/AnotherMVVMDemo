using System.Collections.ObjectModel;

namespace AnotherMVVMDemo
{
    public class StudentViewModel
    {
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return _selectedStudent;
            }
            set
            {
                _selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public StudentViewModel ()
        {
            LoadStudents();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd);
        }
        public ObservableCollection<Student> Students { get; set; }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            students.Add(new Student { FirstName = "Andrey", LastName = "Petrov" });
            students.Add(new Student { FirstName = "Volodya", LastName = "Vasilyev" });
            students.Add(new Student { FirstName = "Stepan", LastName = "Razin"});

            Students = students;
        }

        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete()
        {
            return SelectedStudent != null;
        }

        private void OnAdd()
        {
            Students.Add(new Student { FirstName = "", LastName = "" });
            //AddCommand.RaiseCanExecuteChanged();
        }
    }
}
