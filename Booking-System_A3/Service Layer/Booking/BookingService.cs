using Booking_System_A3.Data_Layer.Booking;

namespace Booking_System_A3.Service_Layer.Booking;

public class BookingService : IBookingService
{
    private IBookingStorage _bookingStorage;

    public BookingService(IBookingStorage bookingStorage)
    {
        _bookingStorage = bookingStorage;
    }

    public bool CreateBooking(int customerId, int employeeId, DateTime date, TimeSpan start, TimeSpan end)
    {
        try
        {
            _bookingStorage.CreateBooking(new DTO.Booking(customerId, employeeId, date, start, end));

        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }

    public ICollection<DTO.Booking> GetBookingsForCustomer(int customerId)
    {
        return _bookingStorage.GetBookingsForCustomer(customerId);
    }

    public ICollection<DTO.Booking> GetBookingsForEmployee(int employeeId)
    {
        return _bookingStorage.GetBookingsForEmployee(employeeId);
    }
}