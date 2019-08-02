using CrazyBooks.Lib.Models;

namespace CrazyBooks.Lib.Services
{
    public class LendResponse
    {
        public LendResponseStatus Status { get; set; }

        public Lend Lend { get; set; }
    }

    public enum LendResponseStatus
    {
        Ok,
        MemberHasLimitOfBooks,
        ThereAreNoAvailableBooks,
    }

}
