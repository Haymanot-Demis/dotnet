public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear {get; set;}

    public Book(string title, string author, string isbn, int publicationYear)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }

}
