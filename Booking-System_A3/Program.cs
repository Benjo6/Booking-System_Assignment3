using Booking_System_A3.Data_Layer.Booking;
using Booking_System_A3.Data_Layer.Customer;
using Booking_System_A3.Data_Layer.Employee;
using Booking_System_A3.DTO;

public class Program
{
    const string connectionString = "Data Source=booking-sys.database.windows.net;Initial Catalog=Booking-System;User ID=user;Password=Secret1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    static void Main(string[] args)
    {
        CustomerStorage customerStorage = new CustomerStorage(connectionString);
        EmployeeStorage employeeStorage = new EmployeeStorage(connectionString);
        BookingStorage bookingStorage = new BookingStorage(connectionString);

        Console.WriteLine("Got customers: ");
        foreach (Customer items in customerStorage.GetCustomers())
        {
            Console.WriteLine(items.ToString());
        }

        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("Got employee: ");
        Console.WriteLine(employeeStorage.GetEmployeeWithId(30));
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine("Got bookings: ");
        Console.WriteLine(bookingStorage.CreateBooking(new Booking(260, 30, new DateTime(2022, 12, 24), new TimeSpan(13, 0, 0),
            new TimeSpan(13, 30, 0))));
        
        
        foreach (Booking items in bookingStorage.GetBookingsForCustomer(20))
        {
            Console.WriteLine(items.ToString());
        }

        Console.WriteLine("The End.");
    }

}