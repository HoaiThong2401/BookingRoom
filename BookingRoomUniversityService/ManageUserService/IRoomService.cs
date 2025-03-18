using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoomUniversityRepository.Entities;

namespace BookingRoomUniversity.Assignment.Service.ManageUserService
{
    public interface IRoomService
    {
        List<Room> getAllRoom();
        void CreateRoom(Room obj);
        void UpdateRoom(Room obj);
        void DeleteRoom(Room obj);
        
    }
}
