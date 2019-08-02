using CrazyBooks.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyBooks.Lib.Services
{
    public class RegisterResponse
    {
        public RegisterResponseStatus Status { get; set; }
        public Member Member { get; set; }
    }

    public enum RegisterResponseStatus
    {
        Ok,
        UserWithEmailAlreadyExists,
        WrongEmail,
        MissingEmail,
        MissingPassword,
        PasswordInsecure
    }
}
