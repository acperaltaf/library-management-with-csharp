public class User
{
    public string Name {get; set;}
    public string UserID {get; set;}

    public User(string name, string userID)
    {
        Name = name;
        UserID = userID;
    }

    public override string ToString()
    {
        return $"Name: {Name} ID: {UserID}";
    }
}