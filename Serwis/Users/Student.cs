namespace Serwis;

public class Student : User
{
    public Student(string firstName, string lastName)
        : base(firstName, lastName)
    {
        UserType = UserType.STUDENT;
    }

}
