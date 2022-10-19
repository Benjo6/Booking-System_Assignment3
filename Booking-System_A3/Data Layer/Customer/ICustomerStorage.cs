namespace Booking_System_A3.Data_Layer.Customer;

public interface ICustomerStorage
{
    public DTO.Customer GetCustomerWithId(int customerId);
    public List<DTO.Customer> GetCustomers();
    public bool CreateCustomer(DTO.Customer customerToCreate);
    List<DTO.Customer> GetCustomerByFirstName(string firstName);
}

