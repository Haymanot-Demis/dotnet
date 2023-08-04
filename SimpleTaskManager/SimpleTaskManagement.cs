public class SimpleTaskManagement{
    private static void Menu(){
        Console.WriteLine("1. Add a task");
        Console.WriteLine("2. Set a task completed");
        Console.WriteLine("3. Display tasks");
        Console.WriteLine("4. Filter tasks by category");
        Console.WriteLine("5. Exit");
    }

    private static void AddTask(TaskManger taskManger){
        Console.WriteLine("Enter task name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter task description");
        string description = Console.ReadLine();
        Console.WriteLine("Enter task category");
        string category = Console.ReadLine();
        taskManger.AddTask(new Task("jkhf786", name, description, category));
    }

    private static void SetTaskCompleted(TaskManger taskManger){
        Console.WriteLine("Enter task id");
        Guid id = Guid.Parse(Console.ReadLine());
        taskManger.SetTaskCompleted(id);
    }
    
    private static void FilterTasksByCategory(TaskManger taskManger){
        Console.WriteLine("Enter category");
        string category = Console.ReadLine();
        taskManger.FilterTasksByCategory(category);
    }
    public static void Main(string[] args){
        TaskManger taskManger = new TaskManger();
        while(true){
            Menu();
            int choice = int.Parse(Console.ReadLine());
            switch(choice){
                case 1:
                    AddTask(taskManger);
                    break;
                case 2:
                    SetTaskCompleted(taskManger);
                    break;
                case 3:
                    taskManger.DisplayTasks();
                    break;
                case 4:
                    FilterTasksByCategory(taskManger);
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    public static void Main(string[] args){
        TaskManger taskManger = new TaskManger();
    }
}
}