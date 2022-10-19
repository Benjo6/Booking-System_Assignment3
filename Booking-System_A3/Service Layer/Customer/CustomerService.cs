using Booking_System_A3.Data_Layer.Customer;

namespace Booking_System_A3.Service_Layer.Customer;

public class CustomerService : ICustomerService
{
    private ICustomerStorage _customerStorage;

    public CustomerService(ICustomerStorage customerStorage)
    {
        _customerStorage = customerStorage;
    }
    public bool CreateCustomer(string firstName, string lastName, DateTime birthdate,string phoneNumber)
    {
        bool okay;

        try
        {  
            return okay = _customerStorage.CreateCustomer(new DTO.Customer(firstName, lastName,phoneNumber));
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public DTO.Customer GetCustomerById(int id)
    {
        return _customerStorage.GetCustomerWithId(id);
    }

    public ICollection<DTO.Customer> GetCustomersByFirstName(string firstName)
    {
        return _customerStorage.GetCustomerByFirstName(firstName);
    }
}