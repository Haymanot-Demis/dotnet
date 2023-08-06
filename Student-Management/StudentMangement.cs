class StudentMangement
{
    // Menu
    public static void Menu()
    {
        Console.WriteLine("1. Add student records");
        Console.WriteLine("2. Display student records");
        Console.WriteLine("3. sereach");
        Console.WriteLine("4. update");
        Console.WriteLine("5. Exit");
    }

    // Add student records
    public static void AddStudentRecords()
    {
        Console.WriteLine("Enter roll number: ");
        int rollNo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter grade: ");
        double grade = Convert.ToDouble(Console.ReadLine());
        Student student = new Student(rollNo, name, age, grade);
        studentList.Add(student);
    }

    // Display student records
    public static void DisplayStudentRecords()
    {
        foreach (var student in studentList.store)
        {
            Console.WriteLine("RollNo: " + student.RollNo);
            Console.WriteLine("Name: " + student.Name);
            Console.WriteLine("Age: " + student.Age);
            Console.WriteLine("Grade: " + student.Grade);
        }
    }

    // search
    public static void Search()
    {
        Console.WriteLine("Enter roll number: ");
        int rollNo = Convert.ToInt32(Console.ReadLine());
        var student = studentList.search(rollNo);
        if (student == null)
        {
            Console.WriteLine("Student not found");
            return;
        }
        Console.WriteLine("RollNo: " + student.RollNo);
        Console.WriteLine("Name: " + student.Name);
        Console.WriteLine("Age: " + student.Age);
        Console.WriteLine("Grade: " + student.Grade);
    }

    // update
    public static void Update()
    {
        Console.WriteLine("Enter roll number: ");
        int rollNo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter grade: ");
        double grade = Convert.ToDouble(Console.ReadLine());
        Student student = new Student(rollNo, name, age, grade);
        studentList.update(rollNo, student);
    }


    public static void Main(string[] args)
    {
        while (true)
        {
            Menu();
            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddStudentRecords();
                    break;
                case 2:
                    DisplayStudentRecords();
                    break;
                case 3:
                    Search();
                    break;
                case 4:
                    Update();
                    break;
                case 5:
                    Cosole.WriteLine("Exit");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
        
    }
}