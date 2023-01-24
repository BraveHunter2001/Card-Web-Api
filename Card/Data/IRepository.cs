namespace Data;

public interface IRepository<T> : IDisposable
{
    Task<ICollection<T>> GetItemsListAsync();
    Task<T> GetItemAsync(int id);
    Task AddItemAsync(T item);
    Task DeleteItemAsync(int id);
    Task UpdateItemAsync(T item);
    Task SaveAsync();
}