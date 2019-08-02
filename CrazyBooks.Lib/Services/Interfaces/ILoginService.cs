using CrazyBooks.Lib.Core;
using CrazyBooks.Lib.Services.Dtos;

namespace CrazyBooks.Lib.Services
{
    public interface ILoginService : IGenericService
    {
        User Authenticate(LoginRequest loginRequest);
    }
}
