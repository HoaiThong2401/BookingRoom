

using BookingRoomUniversityRepository.Entities;
using BookingRoomUniversityRepository.Repositories.UOW;

namespace BookingRoomUniversity.Assignment.Service.ManageUserService.Implements
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public void CreateDepartment(Department obj)
        {
            _unitOfWork.Repository<Department>().AddAsync(obj);
            _unitOfWork.CompleteAsync();
            
        }

        public void DeleteDepartment(Department obj)
        {
            _unitOfWork.Repository<Department>().DeleteAsync(obj);  
        }

        public List<Department> getALLDepartment()
        {
           return _unitOfWork.Repository<Department>().Entities.ToList();
        }

        public void UpdateDepartment(Department obj)
        {
             _unitOfWork.Repository<Department>().UpdateAsync(obj);
        }
    }
}
