using System;
using CrazyBooks.Lib.Core;

namespace CrazyBooks.Lib.Models
{
    public class Lend : Entity
    {
        public Guid MemberId { get; set; }

        public Member Member { get; set; }

        public Guid BookId { get; set; }

        public Book Book { get; set; }
    }
}
