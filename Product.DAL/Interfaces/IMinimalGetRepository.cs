namespace ProductAPI.DAL.Interfaces
{
    public interface IMinimalGetRepository<T>
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, string? search = null);
        Task<T> GetByAsync(Expression<Func<T, bool>> filter, bool tracking = true);
    }
}
