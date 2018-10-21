using System.Collections.ObjectModel;

namespace AnotherMVVMDemo
{
    public class StudentViewModel
    {
        public StudentViewModel ()
        {
            LoadStudents();
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
    }
}
