using Booking_System_A3.DTO;
using Microsoft.Data.SqlClient;

namespace Booking_System_A3.Data_Layer.Booking;

public class BookingStorage : IBookingStorage
{
    private string _connectionString;

    public BookingStorage(string connectionString)
    {
        _connectionString = connectionString;
    }

    private DTO.Booking ReadNextBooking(SqlDataReader reader)
    {
        DTO.Booking booking = new DTO.Booking();
        booking.Id = reader.GetInt32(0);
        booking.CustomerId = reader.GetInt32(1);
        booking.EmployeeId = reader.GetInt32(2);
        booking.Date = reader.GetDateTime(3);
        booking.Start = reader.GetTimeSpan(4);
        booking.End = reader.GetTimeSpan(5);

        return booking;


    }

    public bool CreateBooking(DTO.Booking booking)
    {

        var sql = "insert into Bookings(CustomerId,EmployeeId,AppointmentDay,StartTime,EndTime) values (@cid,@eid,@d,@s,@e)";
        bool okay;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand command=new SqlCommand(sql,conn))
            {
                command.Parameters.AddWithValue("@cid", booking.CustomerId  as object ?? DBNull.Value);
                command.Parameters.AddWithValue("@eid", booking.EmployeeId as object ?? DBNull.Value);
                command.Parameters.AddWithValue("@d", booking.Date as object ?? DBNull.Value);
                command.Parameters.AddWithValue("@s", booking.Start  as object ?? DBNull.Value);
                command.Parameters.AddWithValue("@e", booking.End  as object ?? DBNull.Value);

                try
                {
                    int rows = command.ExecuteNonQuery();
                    okay = rows == 1;
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                    okay = false;
                }
            }
        }

        SmsMessage message = new SmsMessage("The System", "There is a new Booking");
        Console.WriteLine(message);

        return okay;
    }

    public List<DTO.Booking> GetBookingsForCustomer(int customerId)
    {
        var sql = "select * from Bookings where CustomerId =@cid";
        List<DTO.Booking> list = new List<DTO.Booking>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(sql,conn))
            {
                command.Parameters.AddWithValue("@cid", customerId as object ?? DBNull.Value);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ReadNextBooking(reader));
                }
            }
        }

        return list;
    }

    public List<DTO.Booking> GetBookingsForEmployee(int employeeId)
    {
        var sql = "select * from Bookings where EmployeeId =@eid";
        List<DTO.Booking> list = new List<DTO.Booking>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand command = new SqlCommand(sql,conn))
            {
                command.Parameters.AddWithValue("@eid", employeeId as object ?? DBNull.Value);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(ReadNextBooking(reader));
                }
            }
        }

        return list;    
    }
}