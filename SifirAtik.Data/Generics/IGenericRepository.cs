namespace SifirAtik.Data.Generics
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<T> CreateAsync(T entity);

        Task<IQueryable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid guid);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
