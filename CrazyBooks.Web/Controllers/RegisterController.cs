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
    public class RegisterController : ControllerBase
    {
        IRegisterService _registerService { get; set; }

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<RegisterResponse> Post([FromBody] RegisterRequest registerRequest)
        {
            return await Task.Run(() =>
            {
                return _registerService.Register(registerRequest);
            });
        }        
    }
}
