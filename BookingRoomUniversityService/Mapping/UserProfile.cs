using AutoMapper;
using BookingRoomUniversityRepository.Entities;
using BookingRoomUniversityRepository.Repositories.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoomUniversityService.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User,UserResponse>();
        }
    }
}
