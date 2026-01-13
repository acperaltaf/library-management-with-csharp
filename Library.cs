public class Library
{
    private List<Book> Books {get; set;} = new();
    private List<User> Users {get; set;} = new();

    // In this order: <UserID, BookID>
    private Dictionary<string, string> BorrowedBooks = new();

    // private Dictionary<string, string> AvailableBooks = new();

    public void ShowAvailableBooks()
    {
        foreach (Book book in Books)
        {
            if (book.IsBorrowed == false)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }

    // Add or remove individual users
    public void NewUser(User user) => Users.Add(user);
    public void RemoveUser(User user) => Users.Remove(user);

    // Add or remove user group
    public void AddUsers(List<User> users) => Users.AddRange(users);
    public void ShowUsers() => Console.WriteLine(string.Join(",\n", Users));
    public void ShowBooks() => Console.WriteLine(string.Join(",\n", Users));

    // Add or remove individual books
    public void AddBook(Book book) => Books.Add(book);
    public void RemoveBook(Book book) => Books.Remove(book);

    // METHOD TO BORROW BOOKS
    public void BorrowBookByID(User userID, Book bookID)
    {
        if (bookID.IsBorrowed == false)
        {
            BorrowedBooks.Add(userID.UserID, bookID.BookID);
            bookID.IsBorrowed = true;            
        }
    }

    // METHOD FOR RETURNING BORROWED BOOKS
    public void ReturnBook(User user, Book book)
    {
        // Check if the user has the book
        foreach (var userID in BorrowedBooks.Keys)
        {
            if (userID == user.UserID)
            {
                BorrowedBooks.Remove(user.UserID);
                book.IsBorrowed = false;
            }
            else {Console.WriteLine("The user doesn't have this book.");}
        }
    }

}