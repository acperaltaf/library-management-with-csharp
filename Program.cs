
public class Program
{
    public static void Main(string[] args)
    {
        List<User> users = new()
        {
            new("Adres Peralta", "u01"),
            new("Juan Peralta", "u02"),
            new("Janer Peralta", "u03"),
            new("Zaida Peralta", "u04"),
            new("Leonor Fragozo", "u05")
        };

        List<Book> books = new()
        {
            new("Cien años de soledad", "G. G. Marquez", "b01"),
            new("The Game of Thrones", "J. R. R. Martin", "b02"),
            new("Hary Potter", "J. K. Rowling", "b03"),
            new("The Lord of the Ring", "Tolkien", "b04")
        };
        

        Library library = new();

        // Add users to the library
        library.AddUsers(users);
        
        // Add books to the library
        foreach(Book b in books)
        {
            library.AddBook(b);
        }

        // library.LibraryStatus();

        User? user1 = users.FirstOrDefault(u => u.Name == "Adres Peralta");
        Book? book1 = books.FirstOrDefault(b => b.Title == "Cien años de soledad");
        Book? book2 = books.FirstOrDefault(b => b.Title == "The Game of Thrones");

        User? user2 = users.FirstOrDefault(u => u.Name == "Zaida Peralta");
        Book? book3 = books.FirstOrDefault(b => b.Title == "Hary Potter");


        if (user1 != null && user2 != null && book1 != null && book2 != null && book3 != null)
        {
            library.BorrowBook(user1, book1);
            library.BorrowBook(user1, book2);
            library.BorrowBook(user2, book3);
        }
        else
        {
            Console.WriteLine("Usuario o libro no encontrado.");
        }
        library.LibraryStatus();

    }
}