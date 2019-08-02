using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrazyBooks.Lib.Core;
using CrazyBooks.Lib.Models;
using CrazyBooks.Lib.Services.Dtos;

namespace CrazyBooks.Lib.Services
{
    public class RegisterService : IRegisterService
    {
        public ILoginService LoginService { get; set; }

        public IRepository<Member> MembersRepository { get; set; }

        public RegisterService(IRepository<Member> membersRepository, ILoginService loginService)
        {
            MembersRepository = membersRepository;
            LoginService = loginService;
        }


        public virtual RegisterResponse Register(RegisterRequest registerRequest)
        {
            var output = new RegisterResponse();

            if (string.IsNullOrEmpty(registerRequest.Email))
            {
                output.Status = RegisterResponseStatus.MissingEmail;
            }
            else if (!registerRequest.Email.Contains("@"))
            {
                output.Status = RegisterResponseStatus.WrongEmail;
            }
            else if (string.IsNullOrEmpty(registerRequest.Password))
            {
                output.Status = RegisterResponseStatus.MissingPassword;
            }
            else if (registerRequest.Password.Length < 8)
            {
                output.Status = RegisterResponseStatus.PasswordInsecure;
            }

            var member = MembersRepository.GetAll().FirstOrDefault(x => x.Email == registerRequest.Email);

            if (member != null)
            {
                output.Status = RegisterResponseStatus.UserWithEmailAlreadyExists;
            }
            else
            {
                member = new Member
                {
                    Email = registerRequest.Email,
                    Password = registerRequest.Password, 
                    ImageId = registerRequest.ImageId
                };

                MembersRepository.Add(member);
                output.Status = RegisterResponseStatus.Ok;

                var loginRequest = new LoginRequest()
                {
                    Email = registerRequest.Email,
                    Password = registerRequest.Password
                };

                output.Member = LoginService.Authenticate(loginRequest) as Member;
            }

            return output;
            
        }
    }
}
