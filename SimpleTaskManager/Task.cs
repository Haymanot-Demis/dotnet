class Task
{
    public Guid Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public bool IsCompleted { get; set; }
    public Task()
    {
    }

    // object initializer
    public Task(string name, string description, Category category, Guid id = new Guid())
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        IsCompleted = false;
    }
}