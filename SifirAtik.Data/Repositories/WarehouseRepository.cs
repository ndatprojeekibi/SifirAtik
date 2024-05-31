using SifirAtik.Data.Contexts;
using SifirAtik.Data.Generics;
using SifirAtik.Domain.Entities;

namespace SifirAtik.Data.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>
    {
        public WarehouseRepository(DataContext context) : base(context)
        {
        }
    }
}
