using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos.Base;
using SifirAtik.Services.Services.Base;

namespace SifirAtik.Services.Services
{
    public interface IItemService : IBaseService<BaseDto, ResultItem>
    {
        Task<ResultItem> GetUserItemsByIdAsync(Guid guid);

        Task<ResultItem> GetMarketplace();

        Task<ResultItem> GetMarketplaceItem(Guid guid);
    }
}
