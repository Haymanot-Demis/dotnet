class Task
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public bool IsCompleted { get; set; }

    // object initializer
    public Task(string name, string description, Category category)
    {
        Name = name;
        Description = description;
        Category = category;
        IsCompleted = false;
    }

}