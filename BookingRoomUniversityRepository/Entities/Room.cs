using System;
using System.Collections.Generic;

namespace BookingRoomUniversityRepository.Entities;

public partial class Room
{
    public int RoomId { get; set; }

    public int CampusId { get; set; }

    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public DateTime? DeleteTime { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Campus Campus { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
