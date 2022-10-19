namespace Booking_System_A3.DTO;

public class Customer
{
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;

    public Customer(int id, string firstName, string lastName, string phoneNumber)
    {
        _id = id;
        _firstName = firstName;
        _lastName = lastName;
        _phoneNumber = phoneNumber;
    }

    public Customer(string firstName, string lastName, string phoneNumber)
    {
        _firstName = firstName;
        _lastName = lastName;
        _phoneNumber = phoneNumber;
    }

    public Customer()
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
        set => _firstName = value;
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => _phoneNumber = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        return "{"+Id+" , "+FirstName+ " , "+LastName+"}";
    }
}