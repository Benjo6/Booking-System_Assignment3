using Booking_System_A3.Data_Layer.Customer;
using Booking_System_A3.Data_Layer.Employee;
using Booking_System_A3.DTO;
using Booking_System_A3.Service_Layer.Employee;

namespace BookingTests.Integration;

public class EmployeeIntegrationTests
{
    const string connectionString = "Data Source=booking-sys.database.windows.net;Initial Catalog=Booking-System;User ID=user;Password=Secret1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    private IEmployeeService employeeService;
    private IEmployeeStorage employeeStorage;

    [SetUp]
    public void Setup()
    {
        employeeStorage = new EmployeeStorage(connectionString);
        employeeService = new EmployeeService(employeeStorage);
    }

    [Test]
    public void MustSaveEmployeeToDatabaseWhenCallingCreateEmployee()
    {
        //Arrange
        Employee employee = new Employee("Benny", "John");
        employeeService.CreateEmployee(employee);
        
        //Act
        var createdEmployee = employeeStorage.GetEmployeesByFullName(employee.FirstName,employee.LastName).First();
        //Assert
        Assert.That(employee.FirstName, Is.EqualTo(createdEmployee.FirstName));
        Assert.That(employee.LastName, Is.EqualTo(createdEmployee.LastName));

    }

    [Test]
    public void MustGetEmployeesFromDatabaseWhenCallingGetWithId()
    {
        //Arrange
        //Act
        var item = employeeStorage.GetEmployeeWithId(30);
        //Assert
        Assert.That(item.FirstName,Is.EqualTo("Claude"));
        Assert.That(item.LastName,Is.EqualTo("Maxwell"));

    }


    
    

}