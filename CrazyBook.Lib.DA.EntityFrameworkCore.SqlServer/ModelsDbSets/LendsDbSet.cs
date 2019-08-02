using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Models;

namespace CrazyBooks.Lib.DA.EFCore
{
    public class LendsDbSet : CrazyBooksDbSet<Lend>
    {
        public LendsDbSet(CrazybooksContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Lends;
        }
    }
}
