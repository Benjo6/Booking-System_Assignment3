namespace Booking_System_A3.Service_Layer.Booking;

public interface IBookingService
{
    bool CreateBooking(int customerId, int employeeId, DateTime date, TimeSpan start, TimeSpan end);
    ICollection<DTO.Booking> GetBookingsForCustomer(int customerId);
    ICollection<DTO.Booking> GetBookingsForEmployee(int employeeId);

}