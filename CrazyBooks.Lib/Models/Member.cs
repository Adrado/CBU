using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using CrazyBooks.Lib.Core;

namespace CrazyBooks.Lib.Models
{
    public class Member : User
    {
        [JsonIgnore]
        public ICollection<Lend> Lends { get; set; }

        public List<Guid> LendsIds
        {
            get
            {
                //if (Lends == null)
                //    return new List<Guid>();
                //else
                //    return Lends.Select(x => x.Id).ToList();
                
                // esto es lo mismo que lo de arriba pero con el operador ternario
                return Lends == null ? new List<Guid>() : Lends.Select(x => x.Id).ToList();  
            }
        }

        [JsonIgnore]
        public ICollection<Reservation> Reservations { get; set; }

        public List<Guid> ReservationsIds
        {
            get
            {
                return Reservations == null ? new List<Guid>() : Reservations.Select(x => x.Id).ToList();
            }
        }
    }
}
