namespace Booking_System_A3.Data_Layer.Booking;

public interface IBookingStorage
{
    bool CreateBooking(DTO.Booking booking);
    List<DTO.Booking> GetBookingsForCustomer(int customerId);
    List<DTO.Booking> GetBookingsForEmployee(int employeeId);
}