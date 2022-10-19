namespace Booking_System_A3.Data_Layer.Employee;

public interface IEmployeeStorage
{
    bool CreateEmployee(DTO.Employee employee);
    DTO.Employee GetEmployeeWithId(int employeeId);
    List<DTO.Employee> GetEmployeesByFullName(string firstName, string lastName);

}