using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoomUniversityRepository.Entities;
using BookingRoomUniversityRepository.Repositories.UOW;

namespace BookingRoomUniversity.Assignment.Service.ManageUserService.Implements
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public void CreateBooking(Booking obj)
        {
           _unitOfWork.Repository<Booking>().AddAsync(obj);
            _unitOfWork.CompleteAsync();
        }

        public void DeleteBooking(Booking obj)
        {
            _unitOfWork.Repository<Booking>().DeleteAsync(obj);
            _unitOfWork.CompleteAsync();
        }

        public List<Booking> getAllBooking()
        {
            return _unitOfWork.Repository<Booking>().Entities.ToList(); 
        }

        public void UpdateBooking(Booking obj)
        {
            _unitOfWork.Repository<Booking>().UpdateAsync(obj); 
            _unitOfWork.CompleteAsync();
        }
    }
}
