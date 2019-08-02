using CrazyBooks.Lib.Core;
using CrazyBooks.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBooks.Lib.Services
{
    public class ActiveDirectoryAdminService : GenericCrudService<Admin>
    {
        public ActiveDirectoryAdminService(IRepository<Admin> repository)
            : base(repository)
        {

        }

        public override Admin Add(Admin entity)
        {
            // add specific behavior to add windows user
            return base.Add(entity);
        }
    }
}
