using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;
using SifirAtik.Domain.Dtos.Base;

namespace SifirAtik.Client.Services.User
{
    public interface IUserService
    {
        Task<ResultItem> CreateAsync(CreateUserDto dto);

        Task<ResultItem> DeleteAsync(DeleteUserDto dto);

        Task<ResultItem> GetAllAsync();

        Task<ResultItem> GetByIdAsync(Guid guid);

        Task<ResultItem> UpdateUserProfileAsync(UpdateUserProfileDto dto);

        Task<ResultItem> UpdateEmailAsync(UpdateEmailDto dto);

        Task<ResultItem> UpdateAsync(UpdateUserProfileDto dto);
    }
}
