using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Models;

namespace CrazyBooks.Lib.DA.EFCore
{
    public class ReservationsDbSet : CrazyBooksDbSet<Reservation>
    {
        public ReservationsDbSet(CrazybooksContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Reservations;
        }
    }
}
