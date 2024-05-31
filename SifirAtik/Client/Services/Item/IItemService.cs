using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;

namespace SifirAtik.Client.Services.Item
{
    public interface IItemService
    {
        Task<ResultItem> CreateAsync(CreateItemDto dto);

        Task<ResultItem> DeleteAsync(DeleteItemDto dto);

        Task<ResultItem> GetAllAsync();

        Task<ResultItem> GetByIdAsync(Guid guid);

        Task<ResultItem> UpdateAsync(UpdateItemDto dto);

        Task<ResultItem> GetUserItemsById(Guid guid);

        Task<ResultItem> GetMarketplace();

        Task<ResultItem> GetMarketplaceItem(Guid guid);

        Task<ResultItem> AcceptDonatedItem(AcceptDonatedItemDto dto);
    }
}
