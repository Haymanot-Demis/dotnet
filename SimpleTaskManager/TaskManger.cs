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
        var reader = new StreamReader("C:\\Projects\\dotnet\\SimpleTaskManager\\tasks.csv");
        var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture){HasHeaderRecord = false});
        var Tasks = csv.GetRecords<dynamic>();
        tasks = Tasks.ToList();
        DisplayTasks();
    }

    // destructor
    ~TaskManger()
    {
        Console.WriteLine("Saving tasks...");
        var writer = new StreamWriter("C:\\Projects\\dotnet\\SimpleTaskManager\\tasks.csv");
        var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(tasks);
    }

    ~TaskManger()
    {
        var writer = new StreamWriter("tasks.csv");
        var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(tasks);
    }

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
        Console.WriteLine("ID\t\tName\t\tDescription\t\tCategory\t\tCompletion Status");
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}{task.Name}\t\t{task.Description}\t\t{task.Category}\t\t{task.IsCompleted}");
        }
    }

    // filtering taks by category
    public void FilterTasksByCategory(string category)
    {
        Console.WriteLine("ID\t\tName\t\tDescription\t\tCategory\t\tCompletion Status");
        List<Task> filteredTasks = new List<Task>();
        tasks.ForEach(task => {
            if (task.Category == category){
                Console.WriteLine($"{task.Id}\t\t{task.Name}\t\t{task.Description}\t\t{task.Category}\t\t{task.IsCompleted}");
            }
        });
    }
}