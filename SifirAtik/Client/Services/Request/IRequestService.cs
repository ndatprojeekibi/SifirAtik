using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;

namespace SifirAtik.Client.Services.Request
{
    public interface IRequestService
    {
        Task<ResultItem> CreateAsync(CreateRequestDto dto);

        Task<ResultItem> DeleteAsync(DeleteRequestDto dto);

        Task<ResultItem> GetAllAsync();

        Task<ResultItem> GetByIdAsync(Guid guid);

        Task<ResultItem> GetUserDonationRequestsById(Guid guid);

        Task<ResultItem> GetUserAdoptionRequestsById(Guid guid);

        Task<ResultItem> GetAllDonationRequestsAsync();

        Task<ResultItem> GetAllAdoptionRequestsAsync();

        Task<ResultItem> UpdateAsync(UpdateRequestDto dto);
    }
}
