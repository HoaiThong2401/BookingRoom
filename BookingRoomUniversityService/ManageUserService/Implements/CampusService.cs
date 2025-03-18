using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoomUniversityRepository.Entities;
using BookingRoomUniversityRepository.Repositories.UOW;

namespace BookingRoomUniversity.Assignment.Service.ManageUserService.Implements
{
    public class CampusService : ICampusService
    {
        private IUnitOfWork _unitOfWork;

        public CampusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateCampus(Campus obj)
        {
            _unitOfWork.Repository<Campus>().AddAsync(obj);
            _unitOfWork.CompleteAsync();
        }

        public void DeleteCampus(Campus obj)
        {
            _unitOfWork.Repository<Campus>().DeleteAsync(obj);
        }

        public List<Campus> getAllCampus()
        {
            return _unitOfWork.Repository<Campus>().Entities.ToList();
        }

        public void UpdateCampus(Campus obj)
        {
            _unitOfWork.Repository<Campus>().UpdateAsync(obj);
        }
    }
}
