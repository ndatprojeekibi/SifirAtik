using SifirAtik.Domain.Dtos;
using SifirAtik.Common.ResultItems;

namespace SifirAtik.Client.Services.Auth
{
    public interface IAuthService
    {
        Task<ResultItem> LoginAsync(LoginUserDto loginRequest);

        Task<ResultItem> RegisterAsync(RegisterUserDto registerRequest);

        Task<ResultItem> LogoutAsync();

        Task<ResultItem> UpdatePasswordAsync(UpdatePasswordDto dto);
    }
}
