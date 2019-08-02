using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Models;

namespace CrazyBooks.Lib.DA.EFCore
{
    public class AdminsDbSet : CrazyBooksDbSet<Admin>
    {
        public AdminsDbSet(CrazybooksContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Admins;
        }
    }
}
