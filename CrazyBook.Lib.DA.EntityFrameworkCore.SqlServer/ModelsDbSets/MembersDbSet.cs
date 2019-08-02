using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Models;

namespace CrazyBooks.Lib.DA.EFCore
{
    public class MembersDbSet : CrazyBooksDbSet<Member>
    {
        public MembersDbSet(CrazybooksContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Members;
        }
    }
}
