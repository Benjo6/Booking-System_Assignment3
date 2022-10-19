using System.Net.Security;
using Microsoft.Data.SqlClient;

namespace Booking_System_A3.Data_Layer.Customer;

public class CustomerStorage:ICustomerStorage
{
    private string _connectionString;

    public CustomerStorage(string connectionString)
    {
        _connectionString = connectionString;
    }
    private DTO.Customer ReadNextCustomer(SqlDataReader reader)
    {
        DTO.Customer customer = new DTO.Customer();
        customer.Id = reader.GetInt32(0);
        customer.FirstName = reader.GetString(1);
        customer.LastName = reader.GetString(2);
        customer.PhoneNumber = reader.GetString(4);

        return customer;
    }
    

    public DTO.Customer GetCustomerWithId(int customerId)
    {
        var sql = "select * from Customers where Id = @id";
        DTO.Customer customer = new DTO.Customer();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            using (SqlCommand command = new SqlCommand(sql,conn))
            {
                command.Parameters.AddWithValue("@id",customerId as object ?? DBNull.Value);                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customer = ReadNextCustomer(reader);
                }

            }

        }
        return customer;
    }

    public List<DTO.Customer> GetCustomers()
    {
        var sql = "select * from Customers";
        List<DTO.Customer> list = new List<DTO.Customer>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();

            using (SqlCommand command = new SqlCommand(sql, conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    list.Add(ReadNextCustomer(reader));
                }
            }
        }


        return list;

    }

    public bool CreateCustomer(DTO.Customer customerToCreate)
    {
        var sql = "insert into Customers(FirstName, LastName, PhoneNumber) values (@fn,@ln,@pn)";
        bool okay;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(sql,conn))
            {
                command.Parameters.AddWithValue("@fn",customerToCreate.FirstName);
                command.Parameters.AddWithValue("@ln",customerToCreate.LastName);
                command.Parameters.AddWithValue("@pn", customerToCreate.PhoneNumber); 
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

    public List<DTO.Customer> GetCustomerByFirstName(string firstName)
    {
        var sql = "select * from Customers where FirstName =@fn";
        List<DTO.Customer> list = new List<DTO.Customer>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(sql,conn))
            {
                command.Parameters.AddWithValue("@fn", firstName);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ReadNextCustomer(reader));
                }
            }
        }

        return list;        
    }
}