using System;

namespace MVCPatternExample
{
    // Step 2: Model Class
    public class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Grade { get; set; }
    }

    // Step 3: View Class
    public class StudentView
    {
        public void DisplayStudentDetails(string name, string id, string grade)
        {
            Console.WriteLine("Student Details:");
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"ID   : {id}");
            Console.WriteLine($"Grade: {grade}");
            Console.WriteLine();
        }
    }

    // Step 4: Controller Class
    public class StudentController
    {
        private Student _model;
        private StudentView _view;

        public StudentController(Student model, StudentView view)
        {
            _model = model;
            _view = view;
        }

        public void SetStudentName(string name)
        {
            _model.Name = name;
        }

        public void SetStudentId(string id)
        {
            _model.Id = id;
        }

        public void SetStudentGrade(string grade)
        {
            _model.Grade = grade;
        }

        public string GetStudentName() => _model.Name;
        public string GetStudentId() => _model.Id;
        public string GetStudentGrade() => _model.Grade;

        public void UpdateView()
        {
            _view.DisplayStudentDetails(_model.Name, _model.Id, _model.Grade);
        }
    }

    // Step 5: Main Class to Test MVC Implementation
    class Program
    {
        static void Main(string[] args)
        {
            // Create model object
            Student student = new Student
            {
                Name = "Alice",
                Id = "S101",
                Grade = "A"
            };

            // Create view and controller
            StudentView view = new StudentView();
            StudentController controller = new StudentController(student, view);

            // Display initial data
            controller.UpdateView();

            // Update student details
            controller.SetStudentName("Bob");
            controller.SetStudentGrade("B+");

            // Display updated data
            controller.UpdateView();

            Console.ReadKey();
        }
    }
}
