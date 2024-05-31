using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;
using SifirAtik.Domain.Dtos.Base;

namespace SifirAtik.Services.Services
{
    public interface IAuthService
    {
        Task<ResultItem> LoginAsync(AuthDto dto);

        Task<ResultItem> RegisterAsync(AuthDto dto);

        Task<ResultItem> UpdatePasswordAsync(UpdatePasswordDto dto);
    }
}
