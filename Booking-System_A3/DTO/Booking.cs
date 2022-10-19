namespace Booking_System_A3.DTO;

public class Booking
{
    private int _id;
    private int _customerId;
    private int _employeeId;
    private DateTime _date;
    private TimeSpan _start;
    private TimeSpan _end;

    public Booking(int customerId, int employeeId, DateTime date, TimeSpan start, TimeSpan end)
    {
        _customerId = customerId;
        _employeeId = employeeId;
        _date = date;
        _start = start;
        _end = end;
    }

    public Booking()
    {
        
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public int CustomerId
    {
        get => _customerId;
        set => _customerId = value;
    }

    public int EmployeeId
    {
        get => _employeeId;
        set => _employeeId = value;
    }

    public DateTime Date
    {
        get => _date;
        set => _date = value;
    }

    public TimeSpan Start
    {
        get => _start;
        set => _start = value;
    }

    public TimeSpan End
    {
        get => _end;
        set => _end = value;
    }
    public override string ToString()
    {
        return "{ CustomerId:"+CustomerId+" EmployeeId: "+EmployeeId+" Start:"+Start+" End:" +End;
    }
}