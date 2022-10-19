using Booking_System_A3.Data_Layer.Employee;
using Booking_System_A3.DTO;
using Booking_System_A3.Service_Layer.Booking;
using Booking_System_A3.Service_Layer.Employee;
using Moq;

namespace BookingSystemTests;

public class EmployeeTests
{
    //SUT (System Under Test)
    private IEmployeeService employeeService;
    
    //DOT (Depended-on Component)
    private Mock<IEmployeeStorage> employeeStorageMock;

    [SetUp]
    public void Setup()
    {
        employeeStorageMock = new Mock<IEmployeeStorage>();
        employeeService = new EmployeeService(employeeStorageMock.Object);
    }

    [Test]
    public void MustCallStorageWhenCreatingEmployee()
    {
        //Arrange
        
        //Act
        var employee = new Employee("Benjamin","Ćurović");
        
        employeeService.CreateEmployee(employee);
        employeeService.GetEmployeeById(30);

        //Assert
        employeeStorageMock.VerifyAll();
        
    }
}