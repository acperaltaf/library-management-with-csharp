
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
        library.AddUsers(users);
        // library.ShowUsers();

        foreach(Book book in books)
        {
            library.AddBook(book);
        }
    }
}