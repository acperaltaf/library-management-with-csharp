public class Library
{
    private List<Book> Books {get; set;} = new();
    private List<User> Users {get; set;} = new();

    // In this order: <UserID, List<BookID>>
    private Dictionary<string, List<string>> BorrowedBooks = new();

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
    public void ShowBooks() => Console.WriteLine(string.Join(",\n", Books));

    // Add or remove individual books
    public void AddBook(Book book) => Books.Add(book);
    public void RemoveBook(Book book) => Books.Remove(book);

    public void BorrowBookByID(User user, Book book)
    {
        // Verify that the book exists in the library
        if (!Books.Contains(book))
        {
            Console.WriteLine("This book is not in the library.");
            return;
        }

        // Validate that the user exist in the library
        if (!Users.Contains(user))
        {
            Console.WriteLine("This user is not registered in the library.");
            return;
        }

        //  Validate that the book is not on loan
        if (book.IsBorrowed)
        {
            Console.WriteLine($"The book '{book.Title}' is already borrowed.");
            return;
        }

        // Lend book
        if (!BorrowedBooks.ContainsKey(user.UserID))
        {
            BorrowedBooks[user.UserID] = new List<string>();
        }
        BorrowedBooks[user.UserID].Add(book.BookID);
        book.IsBorrowed = true;
        Console.WriteLine($"{user.Name} borrowed '{book.Title}'.");
    }

    // METHOD FOR RETURNING BORROWED BOOKS
    public void ReturnBook(User user, Book book)
    {
        // Verify that the user has borrowed books
        if (!BorrowedBooks.ContainsKey(user.UserID))
        {
            Console.WriteLine($"{user.Name} doesn't have any borrowed books.");
            return;
        }

        // Verify that the user has this specific book
        if (!BorrowedBooks[user.UserID].Contains(book.BookID))
        {
            Console.WriteLine($"{user.Name} doesn't have '{book.Title}' borrowed.");
            return;
        }

        // Return the book
        BorrowedBooks[user.UserID].Remove(book.BookID);
        
        // If the user has no more books, remove their dictionary entry.
        if (BorrowedBooks[user.UserID].Count == 0)
        {
            BorrowedBooks.Remove(user.UserID);
        }
        
        book.IsBorrowed = false;
        Console.WriteLine($"{user.Name} returned '{book.Title}'.");
    }

    public void LibraryStatus()
    {
       Console.WriteLine("\tBooks available: ");
       ShowAvailableBooks();

       Console.WriteLine("\tLibrary users: ");
       ShowUsers();
    }

}