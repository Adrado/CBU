using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Core;

namespace CrazyBooks.Lib.DA.EFCore
{
    public class UsersDbSet : CrazyBooksDbSet<User>
    {
        public UsersDbSet(CrazybooksContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Users;
        }
    }
}
