namespace Booking_System_A3.DTO;

public class SmsMessage
{
    private string _recipient;
    private string _message;

    public SmsMessage(string recipient, string message)
    {
        _recipient = recipient;
        _message = message;
    }

    public string Recipient => _recipient;
    public string Message => _message;

    public override bool Equals(object? obj)
    {
        if (obj is SmsMessage other)
        {
            if (Recipient == other.Recipient && Message == other.Message)
                return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Recipient, Message);
    }
}