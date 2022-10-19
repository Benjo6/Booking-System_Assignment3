using Booking_System_A3.Data_Layer.Employee;

namespace Booking_System_A3.Service_Layer.Employee;

public class EmployeeService : IEmployeeService
{
    private IEmployeeStorage _employeeStorage;

    public EmployeeService(IEmployeeStorage employeeStorage)
    {
        _employeeStorage = employeeStorage;
    }

    public bool CreateEmployee(DTO.Employee employee)
    {
        try
        {
            _employeeStorage.CreateEmployee(employee);
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }

    public DTO.Employee GetEmployeeById(int employeeId)
    {
        return _employeeStorage.GetEmployeeWithId(employeeId);
    }

    public ICollection<DTO.Employee> GetEmployeesByFullName(string firstName, string lastName)
    {
        return _employeeStorage.GetEmployeesByFullName(firstName, lastName);
    }
}