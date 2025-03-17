using AutoMapper;
using BookingRoomUniversityRepository.Entities;
using BookingRoomUniversityRepository.Repositories.Models.Responses;
using BookingRoomUniversityRepository.Repositories.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoomUniversityService.ManageUserService.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserResponse> LoginAsync(string email, string password)
        {
            User user = (await _unitOfWork.Repository<User>().GetAsync())
                .FirstOrDefault( u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Password == password);

            UserResponse userResponse = _mapper.Map<UserResponse>(user);

            Role role = (await _unitOfWork.Repository<Role>().GetAsync())
       .FirstOrDefault(r => r.RoleId == user.RoleId) ?? throw new InvalidDataException($"User: {user.Name} has not been granted access");

            userResponse.RoleName = role.Name;

            return userResponse;
        }
    }
}
