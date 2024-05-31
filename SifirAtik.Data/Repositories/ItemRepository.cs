using SifirAtik.Data.Contexts;
using SifirAtik.Data.Generics;
using SifirAtik.Domain.Entities;

namespace SifirAtik.Data.Repositories
{
    public class ItemRepository : GenericRepository<Item>
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Item>> GetUserItemsByIdAsync(Guid guid)
        {
            return await Task.FromResult(_context.Items.Where(item => item.CreatedById == guid));
        }

        public async Task<IQueryable<Item>> GetMarketplace()
        {
            return await Task.FromResult(_context.Items.Where(item => item.IsDonated && !item.IsAdopted));
        }
    }
}
