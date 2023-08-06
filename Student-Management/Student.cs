class Student
{
    public readonly int RollNo;
    public string Name? {get; set;}
    public int Age? {get; set;}
    public double Grade? {get; set;}  

    public Student(){

    }
    public Student(int rollNo, string name, int age, double grade)
    {
        RollNo = rollNo;
        Name = name;
        Age = age;
        Grade = grade;
    }  
}