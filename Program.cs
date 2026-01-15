
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

        library.LibraryStatus();

        User? user = users.FirstOrDefault(u => u.UserID == "u01");
        Book? book = books.FirstOrDefault(b => b.BookID == "b01");

        if (user != null && book != null)
        {
            library.BorrowBookByID(user, book);
        }
        else
        {
            Console.WriteLine("Usuario o libro no encontrado.");
        }
        library.LibraryStatus();

    }
}