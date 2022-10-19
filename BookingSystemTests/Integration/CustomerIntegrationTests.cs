using Booking_System_A3.Data_Layer.Customer;
using Booking_System_A3.DTO;
using Booking_System_A3.Service_Layer.Customer;

namespace BookingTests.Integration;

public class CustomerIntegrationTests
{
    const string connectionString = "Data Source=booking-sys.database.windows.net;Initial Catalog=Booking-System;User ID=user;Password=Secret1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    private ICustomerService customerService;
    private ICustomerStorage customerStorage;

    [SetUp]
    public void Setup()
    {
        customerStorage = new CustomerStorage(connectionString);
        customerService = new CustomerService(customerStorage);
    }

    [Test]
    public void MustSaveCustomerToDatabaseWhenCallingCreateCustomer()
    {
        //Arrange
        var firstName = "Nilmar";
        var lastName = "b";
        var birthDate = new DateTime(1990, 6, 20);
        var phoneNumber = "20406080";
        customerService.CreateCustomer(firstName, lastName, birthDate,phoneNumber);
        //Act
        var createdCustomer = customerStorage.GetCustomerByFirstName(firstName).First();

        
        //Assert
        Assert.That(createdCustomer.FirstName, Is.EqualTo(firstName));
        Assert.That(createdCustomer.LastName, Is.EqualTo(lastName));
    }

    [Test]
    public void MustGetCustomerFromDatabaseWhenCallingGetId()
    {
        //Arrange

        //Act
        var item = customerStorage.GetCustomerWithId(70);

        //Assert
        Assert.That(item.FirstName,Is.EqualTo("Veronika"));
        Assert.That(item.LastName,Is.EqualTo("Stillwell"));
    }

    [Test]
    public void MustGetAllCustomersWhenCallingGetCustomers()
    {
        //Arrange
        
        //Act
        var actual = 18;
        var expected = customerStorage.GetCustomers().Count;

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }


}