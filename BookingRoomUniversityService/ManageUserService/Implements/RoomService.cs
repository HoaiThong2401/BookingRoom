using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoomUniversityRepository.Entities;
using BookingRoomUniversityRepository.Repositories.UOW;

namespace BookingRoomUniversity.Assignment.Service.ManageUserService.Implements
{
    public class RoomService : IRoomService
    {
        private IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateRoom(Room obj)
        {
            _unitOfWork.Repository<Room>().AddAsync(obj);
            _unitOfWork.CompleteAsync();
        }

        public void DeleteRoom(Room obj)
        {
            _unitOfWork.Repository<Room>().DeleteAsync(obj);
            _unitOfWork.CompleteAsync();
        }

        public List<Room> getAllRoom()
        {
           return _unitOfWork.Repository<Room>().Entities.ToList();
        }

        public void UpdateRoom(Room obj)
        {
            _unitOfWork.Repository<Room>().UpdateAsync(obj);
            _unitOfWork.CompleteAsync();
        }
    }
}
