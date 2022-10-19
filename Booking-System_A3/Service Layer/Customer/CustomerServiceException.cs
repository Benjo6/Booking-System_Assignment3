using System.Transactions;

namespace Booking_System_A3.Service_Layer.Customer;

[Serializable]
public class CustomerServiceException : Exception
{ 
    public CustomerServiceException(Exception e)
        : base(String.Format("Error: {0}",e))
    {
    }
}