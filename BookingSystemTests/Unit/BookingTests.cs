using Booking_System_A3.Data_Layer.Booking;
using Booking_System_A3.DTO;
using Booking_System_A3.Service_Layer.Booking;
using Moq;

namespace BookingSystemTests;

public class BookingTests
{
    //SUT (System Under Test)
    private IBookingService bookingService;

    //DOT (Depended-on Component)
    private Mock<IBookingStorage> bookingStorageMock;

    [SetUp]
    public void Setup()
    {
        bookingStorageMock = new Mock<IBookingStorage>();
        bookingService = new BookingService(bookingStorageMock.Object);
    }

    [Test]
    public void MustCallStorageInAllMethods()
    {
        //Arrange
        
        //Act
        var customerId = 20;
        var employeeId = 10;
        var date = new DateTime(2022, 12, 24);
        var start = new TimeSpan(14, 0, 0);
        var end = new TimeSpan(14, 30, 0);
        bookingService.CreateBooking(customerId, employeeId, date, start, end);
        bookingService.GetBookingsForCustomer(20);
        bookingService.GetBookingsForEmployee(30);

        //Assert
        bookingStorageMock.VerifyAll();

    }
}