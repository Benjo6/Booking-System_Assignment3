using Microsoft.VisualBasic;

namespace Booking_System_A3.Service_Layer.Customer;

public interface ICustomerService
{
    bool CreateCustomer(string firstName, string lastName, DateTime birthdate, string phoneNumber);
    DTO.Customer GetCustomerById(int id);
    ICollection<DTO.Customer> GetCustomersByFirstName(string firstName);

}