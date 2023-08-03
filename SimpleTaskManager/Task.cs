class Task
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool IsCompleted { get; set; }
    public Task()
    {
    }

    // object initializer
    // public Task(string name, string description, Category category)
    public Task(string name, string description, string category, Guid id = new Guid())
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        IsCompleted = false;
    }
}