

using BookingRoomUniversityRepository.Entities;

namespace BookingRoomUniversity.Assignment.Service.ManageUserService
{
    public interface IBookingService
    {
        List<Booking> getAllBooking();
        void CreateBooking(Booking obj);
        void UpdateBooking(Booking obj);
        void DeleteBooking(Booking obj);

    }
}
