﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoomUniversityRepository.Repositories.Models.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
