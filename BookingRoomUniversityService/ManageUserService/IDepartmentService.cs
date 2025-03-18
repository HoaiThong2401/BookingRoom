using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoomUniversityRepository.Entities;

namespace BookingRoomUniversity.Assignment.Service.ManageUserService
{
    public interface IDepartmentService
    {
         List<Department> getALLDepartment();
        void CreateDepartment(Department obj);
        void UpdateDepartment(Department obj);
        void DeleteDepartment(Department obj);

    }
}
