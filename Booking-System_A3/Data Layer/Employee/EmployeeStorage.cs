using Microsoft.Data.SqlClient;

namespace Booking_System_A3.Data_Layer.Employee;

public class EmployeeStorage :IEmployeeStorage
{
    private string _connectionString;

    public EmployeeStorage(string connectionString)
    {
        _connectionString = connectionString;
    }
    private DTO.Employee ReadNextEmployee(SqlDataReader reader)
    {
        DTO.Employee employee = new DTO.Employee();
        employee.Id = reader.GetInt32(0);
        employee.FirstName = reader.GetString(1);
        employee.LastName = reader.GetString(2);

        return employee;
    }

    public bool CreateEmployee(DTO.Employee employee)
    {
        var sql = "insert into Employees(FirstName, LastName) values (@fn,@ln)";
        bool okay = false;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(sql,conn))
            {
                command.Parameters.AddWithValue("@fn",employee.FirstName);
                command.Parameters.AddWithValue("@ln",employee.LastName);

                try
                {
                    int rows = command.ExecuteNonQuery();
                    okay = rows == 1;

                }
                catch (Exception e)
                {
                    okay = false;
                }

            }
        }

        return okay;    
    }

    public DTO.Employee GetEmployeeWithId(int employeeId)
    {
            var sql = "select * from Employees where Id = @id";
            DTO.Employee employee = new DTO.Employee();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    command.Parameters.AddWithValue("@id",employeeId as object ?? DBNull.Value);                
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employee = ReadNextEmployee(reader);
                    }

                }

            }
            return employee; 
    }
    public List<DTO.Employee> GetEmployeesByFullName(string firstName,string lastName)
    {
        var sql = "select * from Employees where FirstName = @fn and LastName = @ln";
        List<DTO.Employee> list = new List<DTO.Employee>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(sql,conn))
            {
                command.Parameters.AddWithValue("@fn", firstName);
                command.Parameters.AddWithValue("@ln", lastName);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ReadNextEmployee(reader));
                }
            }
        }

        return list;        
    }
    
}