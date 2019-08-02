using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using CrazyBooks.Lib.Core;

namespace CrazyBooks.Lib.Models
{
    public class Room : Entity
    {
        public string Code { get; set; }

        public int Capacity { get; set; }

        public bool IsAdapted { get; set; }

        [JsonIgnore]
        public ICollection<Lend> Reservations { get; set; }

        public List<Guid> ReservationsIds
        {
            get
            {
                return Reservations == null ? new List<Guid>() : Reservations.Select(x => x.Id).ToList();
            }
        }
    }
}
