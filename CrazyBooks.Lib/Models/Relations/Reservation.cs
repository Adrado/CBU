using System;
using CrazyBooks.Lib.Core;

namespace CrazyBooks.Lib.Models
{
    public class Reservation : Entity
    {
        public Guid MemberId { get; set; }

        public Member Member { get; set; }

        public Guid RoomId { get; set; }

        public Room Room { get; set; }

        public DateTime StartsOn { get; set; }
        
        public DateTime EndsOn { get; set; }
    }
}
