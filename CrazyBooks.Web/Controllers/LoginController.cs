using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyBooks.Lib.Core;
using CrazyBooks.Lib.Services;
using CrazyBooks.Lib.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyBooks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService { get; set; }

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<User> Post([FromBody] LoginRequest loginRequest)
        {
            return await Task.Run(() =>
            {
                return _loginService.Authenticate(loginRequest);
            });
        }        
    }
}
