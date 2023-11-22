namespace Client.Application.Contracts;

public interface IDataService<T, in TKey> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(TKey id);
    Task<T> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(TKey id);
}
