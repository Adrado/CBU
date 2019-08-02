using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Models;
using CrazyBooks.Lib.Core;

namespace CrazyBooks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly ICrudService<Admin> _adminsService;

        public AdminsController(ICrudService<Admin> adminsService)
        {
            _adminsService = adminsService;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return await _adminsService.GetAll().ToListAsync();
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(Guid id)
        {
            return await Task.Run(() =>
            {
                var admin = _adminsService.GetAll().FirstOrDefault(x => x.Id == id);

                if (admin == null)
                {
                    return NotFound();
                }

                return new ActionResult<Admin>(admin);
            });
        }

        // PUT: api/Admins/5
        [HttpPut]
        public async Task<ActionResult<Admin>> PutAdmin(Admin admin)
        {
            return await Task.Run(() =>
            {
                var output = _adminsService.Update(admin);
                return new ActionResult<Admin>(output);
            });
        }

        // POST: api/Admins
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            return await Task.Run(() =>
            {
                var output = _adminsService.Add(admin);
                return new ActionResult<Admin>(output);
            });
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteAdmin(Guid id)
        {
            return await Task.Run(() =>
            {
                return _adminsService.Delete(id);
            });
        }
    }
}
