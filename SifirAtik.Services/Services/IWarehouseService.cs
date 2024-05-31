using SifirAtik.Common.ResultItems;
using SifirAtik.Domain.Dtos.Base;
using SifirAtik.Services.Services.Base;

namespace SifirAtik.Services.Services
{
    public interface IWarehouseService : IBaseService<BaseDto, ResultItem>
    {
        Task<ResultItem> GetNames();
    }
}
