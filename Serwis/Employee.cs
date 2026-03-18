namespace Serwis;

public class Employee : User
{
    public string Position { get; set; }
    public string Department { get; set; }

    public Employee(string firstName, string lastName) 
        : base(firstName, lastName)
    {
        UserType = UserType.Employee;
    }
}
