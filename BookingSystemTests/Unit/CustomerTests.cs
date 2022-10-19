using Booking_System_A3.Data_Layer.Customer;
using Booking_System_A3.DTO;
using Booking_System_A3.Service_Layer.Customer;
using Moq;

namespace BookingSystemTests;

public class CustomerTests
{
    //SUT (System Under Test)
    private ICustomerService customerService;

    //DOT (Depended-on Component)
    private Mock<ICustomerStorage> customerStorageMock;
    
    [SetUp]
    public void Setup()
    {
        customerStorageMock = new Mock<ICustomerStorage>();
        customerService = new CustomerService(customerStorageMock.Object);
    }

    [Test]
    public void MustCallStorageInAllMethods()
    {
        //Arrange
        
        //Act
        var firstName = "a";
        var lastName = "b";
        var birthDate = new DateTime(1990, 6, 20);
        var phoneNumber = "20406080";
        customerService.CreateCustomer(firstName, lastName, birthDate,phoneNumber);
        customerService.GetCustomerById(30);
        customerService.GetCustomersByFirstName("Jacalyn");

        //Assert
        customerStorageMock.VerifyAll();
    }
}