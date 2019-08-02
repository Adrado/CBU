using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyBooks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        // GET: api/Images
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        

        // POST: api/Images
        [HttpPost]
        public async Task<string> Post([FromBody] string input)
        {
            return await Task.Run(() =>
            {
                var bytes = Convert.FromBase64String(input);

                string hash;
                using (var sha1 = new SHA1CryptoServiceProvider())
                {
                    hash = Convert.ToBase64String(sha1.ComputeHash(bytes));
                    hash = string.Concat(hash.ToCharArray().Where(x => char.IsLetterOrDigit(x)));
                }

                using (var ms = new MemoryStream(bytes))
                {
                    var img = Image.FromStream(ms);
                    img.Save("wwwroot/images/" + hash + ".png", ImageFormat.Png);
                }

                return HttpUtility.UrlEncode(hash);
            });
        }
    }
}
