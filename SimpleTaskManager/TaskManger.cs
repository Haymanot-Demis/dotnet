using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;
class TaskManger
{
    List<Task> tasks = new List<Task>();

    // constructor
    public TaskManger()
    {
<<<<<<< HEAD
        var reader = new StreamReader("C:\\Projects\\dotnet\\SimpleTaskManager\\tasks.csv");
        var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture){HasHeaderRecord = false});
        var Tasks = csv.GetRecords<dynamic>();
=======
        using var reader = new StreamReader("tasks.csv");
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture){HasHeaderRecord = false});
        var Tasks = csv.GetRecords<Task>();
>>>>>>> 19fc031e862ad152f14f588e3541a8f6b41e62f7
        tasks = Tasks.ToList();
        DisplayTasks();
    }

    // destructor
<<<<<<< HEAD
    ~TaskManger()
    {
        Console.WriteLine("Saving tasks...");
        var writer = new StreamWriter("C:\\Projects\\dotnet\\SimpleTaskManager\\tasks.csv");
        var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(tasks);
    }
=======
    // ~TaskManger()
    // {
    //     var writer = new StreamWriter("tasks.csv");
    //     var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    //     csv.WriteRecords(tasks);
    // }
>>>>>>> 19fc031e862ad152f14f588e3541a8f6b41e62f7

    // method for Adding a task
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }
    // Set a task completed
    public void SetTaskCompleted(Guid id)
    {
       tasks.Find(task => task.Id == id).IsCompleted = true;
    }

    // displaying tasks in a table
    public void DisplayTasks()
    {
<<<<<<< HEAD
        Console.WriteLine("ID\t\tName\t\tDescription\t\tCategory\t\tCompletion Status");
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}{task.Name}\t\t{task.Description}\t\t{task.Category}\t\t{task.IsCompleted}");
=======
        Console.WriteLine("Name\t\tDescription\t\tCategory\t\tCompletion Status");
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Name}\t\t{task.Description}\t\t{task.Category}\t\t{task.IsCompleted}");
>>>>>>> 19fc031e862ad152f14f588e3541a8f6b41e62f7
        }
    }

    // filtering taks by category
<<<<<<< HEAD
    // public void FilterTasksByCategory(Category category)
    public void FilterTasksByCategory(string category)
    {
        Console.WriteLine("ID\t\tName\t\tDescription\t\tCategory\t\tCompletion Status");
        List<Task> filteredTasks = new List<Task>();
        tasks.ForEach(task => {
            if (task.Category == category){
                Console.WriteLine($"{task.Id}\t\t{task.Name}\t\t{task.Description}\t\t{task.Category}\t\t{task.IsCompleted}");
=======
    public void FilterTasksByCategory(Category category)
    {
        Console.WriteLine("Name\t\tDescription\t\tCategory\t\tCompletion Status");
        List<Task> filteredTasks = new List<Task>();
        tasks.ForEach(task => {
            if (task.Category == category){
                Console.WriteLine($"{task.Name}\t\t{task.Description}\t\t{task.Category}\t\t{task.IsCompleted}");
>>>>>>> 19fc031e862ad152f14f588e3541a8f6b41e62f7
            }
        });
    }
}