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
    public class BooksController : ControllerBase
    {
        private readonly ICrudService<Book> _booksService;

        public BooksController(ICrudService<Book> booksService)
        {
            _booksService = booksService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _booksService.GetAll().ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            return await Task.Run(() =>
            {
                var book = _booksService.GetAll().FirstOrDefault(x => x.Id == id);

                if (book == null)
                {
                    return NotFound();
                }

                return new ActionResult<Book>(book);
            });
        }

        // PUT: api/Books/5
        [HttpPut]
        public async Task<ActionResult<Book>> PutBook(Book book)
        {
            return await Task.Run(() =>
            {
                var output = _booksService.Update(book);
                return new ActionResult<Book>(output);
            });
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            return await Task.Run(() =>
            {
                var output = _booksService.Add(book);
                return new ActionResult<Book>(output);
            });
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteBook(Guid id)
        {
            return await Task.Run(() =>
            {
                return _booksService.Delete(id);
            });
        }
    }
}
