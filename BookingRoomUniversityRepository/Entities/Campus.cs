using System;
using System.Collections.Generic;

namespace BookingRoomUniversityRepository.Entities;

public partial class Campus
{
    public int CampusId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeleteTime { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
