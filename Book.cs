public class Book
{
    public string Title {get;}
    public string Author {get;}
    public string BookID {get;}
    public bool IsBorrowed {get; internal set;}
    public Book(string title, string author, string id)
    {
        Title = title;
        Author = author;
        BookID = id;
        IsBorrowed = false;
    }
    public override string ToString()
    {
        return $"Name: {Title} ID: {BookID}";
    }
}