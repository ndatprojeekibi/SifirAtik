using Microsoft.EntityFrameworkCore;
using SifirAtik.Domain.Entities;
using SifirAtik.Data.Contexts;
using SifirAtik.Data.Generics;

namespace SifirAtik.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dataContext.Set<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Dictionary<Guid, string>> GetUserNamesByIdsAsync(IEnumerable<Guid> userIds)
        {
            return await _dataContext.Users
                .Where(user => userIds.Contains(user.Guid))
                .ToDictionaryAsync(user => user.Guid, user => $"{user.Name} {user.Surname}");
        }

    }
}
