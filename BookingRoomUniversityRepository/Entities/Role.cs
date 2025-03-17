using System;
using System.Collections.Generic;

namespace BookingRoomUniversityRepository.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeleteTime { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
