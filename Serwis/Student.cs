namespace Serwis;

public class Student : User
{
    public string IndexNumber { get; set; }
    public string FieldOfStudy { get; set; }

    public Student(string firstName, string lastName)
        : base(firstName, lastName)
    {
        UserType = UserType.STUDENT;
    }

}
