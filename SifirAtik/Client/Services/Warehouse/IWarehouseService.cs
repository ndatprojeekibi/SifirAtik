using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos;

namespace SifirAtik.Client.Services.Warehouse
{
    public interface IWarehouseService
    {
        Task<ResultItem> CreateAsync(CreateWarehouseDto dto);

        Task<ResultItem> DeleteAsync(DeleteWarehouseDto dto);

        Task<ResultItem> GetAllAsync();

        Task<ResultItem> GetByIdAsync(Guid guid);

        Task<ResultItem> UpdateAsync(UpdateWarehouseDto dto);

        Task<ResultItem> GetNames();
    }
}
