using BookingRoomUniversityRepository.Repositories.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoomUniversityService.ManageUserService
{
    public interface IAuthService
    {
        Task<UserResponse> LoginAsync(string email, string password);
    }
}
