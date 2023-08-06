class StudentList<T> where T: Student
{
    List<T> store = new List<T>();
    public void Add(T item)
    {
        store.Add(item);
    }

    public void Remove(T item)
    {
        store.Remove(item);
    }

    public T search(int rollNo)
    {
        var item = store.Single(x => x.RollNo == rollNo);
        if (item == null)
        {
            Console.WriteLine("Student not found");
            return null;
        }
        return item;
    }

    public T update(int rollNo, T DTO)
    {
        var item = search(rollNo);
        if (item == null)
        {
            Console.WriteLine("Student not found");
            return null;
        }

        // iterating over properties of T
        foreach (var property in typeof(T).GetProperties())
        {
            // if property is not null, update it
            if (property.GetValue(DTO) != null)
            {
                property.SetValue(item, property.GetValue(DTO));
            }
        }
        store[item] = DTO;
        return DTO;
    }

}