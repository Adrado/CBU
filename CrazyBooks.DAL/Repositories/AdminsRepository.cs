using CrazyBooks.Lib.Core;
using CrazyBooks.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBooks.Lib.DAL.Repositories
{
    public class AdminsRepository : GenericRepository<Admin>
    {
        public AdminsRepository(IDbSet<Admin> dbSet)
            : base(dbSet)
        {

        }

        public override Admin Add(Admin entity)
        {
            // todo: specifc network logic

            return base.Add(entity);
        }
    }
}
