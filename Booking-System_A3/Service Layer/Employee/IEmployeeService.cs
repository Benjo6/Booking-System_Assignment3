namespace Booking_System_A3.Service_Layer.Employee;

public interface IEmployeeService
{
    bool CreateEmployee(DTO.Employee employee);
    DTO.Employee GetEmployeeById(int employeeId);
    ICollection<DTO.Employee> GetEmployeesByFullName(string firstName, string lastName);

}