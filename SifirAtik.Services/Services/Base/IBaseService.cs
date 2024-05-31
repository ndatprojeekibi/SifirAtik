namespace SifirAtik.Services.Services.Base
{
    public interface IBaseService<TSource, TResult> where TSource : class, new() where TResult : class
    {
        /// <summary>
        /// Adds a new record to the database.
        /// </summary>
        /// <param name="dto">The data object representing the record to be added.</param>
        /// <returns>A task representing the asynchronous operation with the result of the operation.</returns>
        Task<TResult> CreateAsync(TSource dto);
        /// <summary>
        /// Retrieves all records from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation with the result of the retrieval.</returns>
        Task<TResult> GetAllAsync();
        /// <summary>
        /// Retrieves a record from the database based on its unique ID.
        /// </summary>
        /// <param name="id">The ID of the record to retrieve.</param>
        /// <returns>A task representing the asynchronous operation with the result of the retrieval.</returns>
        Task<TResult> GetByIdAsync(Guid guid);
        /// <summary>
        /// Updates an existing record in the database.
        /// </summary>
        /// <param name="dto">The data object representing the updated record.</param>
        /// <returns>A task representing the asynchronous operation with the result of the retrieval.</returns>
        Task<TResult> UpdateAsync(TSource dto);
        /// <summary>
        /// Deletes a record from the database permanently.
        /// </summary>
        /// <param name="dto">The data object representing the record to be deleted.</param>
        /// <returns>A task representing the asynchronous operation with the result of the deletion.</returns>
        Task<TResult> DeleteAsync(TSource dto);
    }
}
