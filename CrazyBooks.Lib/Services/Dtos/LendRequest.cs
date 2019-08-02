using System;

namespace CrazyBooks.Lib.Services
{
    public class LendRequest
    {
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
    }
}
