namespace Serwis;

public abstract class User
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; protected set; }

    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }


    public override string ToString()
    {
        return $"{FirstName} {LastName} ({UserType})";
    }
}
