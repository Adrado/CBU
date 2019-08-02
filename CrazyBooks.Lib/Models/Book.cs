using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using CrazyBooks.Lib.Core;

namespace CrazyBooks.Lib.Models
{
    public class Book : Entity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public int Edition { get; set; }

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
    }
}
