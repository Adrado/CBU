using CrazyBooks.Lib.Core;
using CrazyBooks.Lib.Services.Dtos;

namespace CrazyBooks.Lib.Services
{
    public interface IRegisterService
    {
        RegisterResponse Register(RegisterRequest registerRequest);
    }
}
