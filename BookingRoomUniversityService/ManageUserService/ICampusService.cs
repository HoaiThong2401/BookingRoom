using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoomUniversityRepository.Entities;

namespace BookingRoomUniversity.Assignment.Service.ManageUserService
{
    public interface ICampusService
    {
        List<Campus> getAllCampus();
        void CreateCampus(Campus obj);
        void UpdateCampus(Campus obj);
        void DeleteCampus(Campus obj);

    }
}
