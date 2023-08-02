public class LibraryCatalog{
    public static void Main(string[] args){
        Console.WriteLine("Enter name of library: ");
        string library_name = Console.ReadLine(); 
        Console.WriteLine("Enter address of library: ");
        string library_address = Console.ReadLine();
        Library library = new Library(library_name, library_address);
        int choice;
        do{
            System.Console.WriteLine("1. Add Book");
            System.Console.WriteLine("2. Add Media Item");
            System.Console.WriteLine("3. Remove Book");
            System.Console.WriteLine("4. Remove Media Item");
            System.Console.WriteLine("5. Print Catalog");
            System.Console.WriteLine("6. Exit");
            System.Console.WriteLine("Enter your choice");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter title of book: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter author of book: ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter ISBN of book: ");
                    string isbn = Console.ReadLine();
                    Console.WriteLine("Enter publication year of book: ");
                    int publication_year = int.Parse(Console.ReadLine());
                    Book book = new Book(title, author, isbn, publication_year);
                    library.AddBooks(book);
                    break;
                case 2 : 
                    Console.WriteLine("Enter title of media item: ");
                    string media_title = Console.ReadLine();
                    Console.WriteLine("Enter media type of media item: ");
                    string media_type = Console.ReadLine();
                    Console.WriteLine("Enter duration of media item: ");
                    int duration = int.Parse(Console.ReadLine());
                    MediaItems media_item = new MediaItems(media_title, media_type, duration);
                    library.AddMediaItems(media_item);
                    break;
                case 3:
                    Console.WriteLine("Enter id of book to remove: ");
                    Guid id = Guid.Parse(Console.ReadLine());
                    library.RemoveBooks(id);
                    break;
                case 4:
                    Console.WriteLine("Enter id of media item to remove: ");
                    Guid media_id = Guid.Parse(Console.ReadLine());
                    library.RemoveMediaItems(media_id);
                    break;
                case 5:
                    library.PrintCatalog();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;          
                default:
                Console.WriteLine("Invalid choice, try again");
                break;
            }
        }while(choice != 6);
    }
}