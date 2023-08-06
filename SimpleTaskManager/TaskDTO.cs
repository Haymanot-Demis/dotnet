public class TaskDTO
{
    public string Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool IsCompleted { get; set; }

    // Constructor to instantiate a TaskDTO object
    public TaskDTO(string id, string name, string description, string category, bool isCompleted)
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        IsCompleted = isCompleted;
    }


}