using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Models;

namespace CrazyBooks.Lib.DA.EFCore
{
    public class RoomsDbSet : CrazyBooksDbSet<Room>
    {
        public RoomsDbSet(CrazybooksContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Rooms;
        }
    }
}
