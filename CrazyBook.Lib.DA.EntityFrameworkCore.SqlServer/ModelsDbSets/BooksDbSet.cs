using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Models;

namespace CrazyBooks.Lib.DA.EFCore
{
    public class BooksDbSet : CrazyBooksDbSet<Book>
    {
        public BooksDbSet(CrazybooksContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Books;
        }
    }
}
