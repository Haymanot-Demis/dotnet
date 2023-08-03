public class Library{
    public string Name {get; set;}
    public string Address {get; set;}
    public List<Book> Books {get; set;}
    public List<MediaItems> MediaItems {get; set;}

    public Library(string name, string address){
        Name = name;
        Address = address;
        Books = new List<Book>();
        MediaItems = new List<MediaItems>();
    }
    public void AddBooks(Book book){
        Books.Add(book);
    }

    public void AddMediaItems(MediaItems mediaItem){
        MediaItems.Add(mediaItem);
    }

    public void RemoveBooks(Guid id){
        Book book_to_remove = Books.Find(book => book.Id == id);
        Books.Remove(book_to_remove);
    }

    public void RemoveMediaItems(Guid id){
        MediaItems mediaItem = MediaItems.Find(mediaItem => mediaItem.Id == id);
        MediaItems.Remove(mediaItem);
    }

    public override string ToString(){
        return $"Name: {Name}\nAddress: {Address}";
    }

    public void PrintCatalog(){
        Console.WriteLine($"\nLibrary Name: {Name}\nAddress: {Address}\n");
        Console.WriteLine("Books:\n");

        foreach (Book book in Books)
        {
            Console.WriteLine($"Title: {book.Title}\nAuthor: {book.Author}\nISBN: {book.ISBN}\nPublication Year: {book.PublicationYear}");
        }
        Console.WriteLine("\nMedia Items:\n");
        
        foreach (MediaItems mediaItem in MediaItems)
        {
            Console.WriteLine($"Title: {mediaItem.Title}\nMedia Type: {mediaItem.MediaType}\nDuration: {mediaItem.Duration}");
        }
    }

}