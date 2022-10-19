namespace Booking_System_A3.DTO;

public class Employee
{
    private int _id;
    private string _firstName;
    private string _lastName;

    public Employee(int id, string firstName, string lastName)
    {
        _id = id;
        _firstName = firstName;
        _lastName = lastName;
    }


    public Employee(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
    }

    public Employee()
    {
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
    }
    public override string ToString()
    {
        return "{ Id:"+Id+" First Name:"+FirstName+" Last Name:"+LastName;
    }
}