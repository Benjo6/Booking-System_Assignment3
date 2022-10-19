using Booking_System_A3.Data_Layer.Booking;
using Booking_System_A3.Service_Layer.Booking;

namespace BookingTests.Integration;

public class BookingIntegrationTests
{
    const string connectionString = "Data Source=booking-sys.database.windows.net;Initial Catalog=Booking-System;User ID=user;Password=Secret1!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    private IBookingService bookingService;
    private IBookingStorage bookingStorage;

    [SetUp]
    public void Setup()
    {
        bookingStorage = new BookingStorage(connectionString);
        bookingService = new BookingService(bookingStorage);
    }

    [Test]
    public void MustSaveBookingToDatabaseWhenCallingCreateBooking()
    {
        //Arrange
        var customerId = 270;
        var employeeId = 30;
        var date = new DateTime(2022, 12, 22);
        var start = new TimeSpan(15, 0, 0);
        var end = new TimeSpan(15, 30, 0);

        bookingService.CreateBooking(customerId, employeeId, date, start, end);
        //Act
        var createdBooking = bookingStorage.GetBookingsForCustomer(270).First();
        //Assert
        Assert.That(employeeId, Is.EqualTo(createdBooking.EmployeeId));
        Assert.That(start, Is.EqualTo(createdBooking.Start));
        Assert.That(end, Is.EqualTo(createdBooking.End));
    }

    [Test]
    public void MustGetBookingFromDatabaseByEmployeeId()
    {
        //Arrange
        //Act
        var expected = bookingStorage.GetBookingsForEmployee(40).Count();
        //Assert
        Assert.That(expected, Is.EqualTo(1));
        
    }

}