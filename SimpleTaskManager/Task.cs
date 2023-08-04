class Task
{
<<<<<<< HEAD
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
=======
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public bool IsCompleted { get; set; }

    // object initializer
    public Task(string name, string description, Category category)
    {
>>>>>>> 19fc031e862ad152f14f588e3541a8f6b41e62f7
        Name = name;
        Description = description;
        Category = category;
        IsCompleted = false;
    }
<<<<<<< HEAD
=======

>>>>>>> 19fc031e862ad152f14f588e3541a8f6b41e62f7
}