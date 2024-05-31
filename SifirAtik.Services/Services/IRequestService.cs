using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos.Base;
using SifirAtik.Services.Services.Base;

namespace SifirAtik.Services.Services
{
    public interface IRequestService : IBaseService<BaseDto, ResultItem>
    {
        Task<ResultItem> GetUserDonationRequestsByIdAsync(Guid guid);

        Task<ResultItem> GetUserAdoptionRequestsByIdAsync(Guid guid);

        Task<ResultItem> GetAllDonationRequestsAsync();

        Task<ResultItem> GetAllAdoptionRequestsAsync();
    }
}
