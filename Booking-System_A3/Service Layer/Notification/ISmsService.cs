using Booking_System_A3.DTO;

namespace Booking_System_A3.Service_Layer.Notification;

public interface ISmsService
{
    bool SendSms(SmsMessage message);
}