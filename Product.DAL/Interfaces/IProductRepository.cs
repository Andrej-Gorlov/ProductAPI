namespace ProductAPI.DAL.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAsync(Expression<Func<Product, bool>>? filter = null, string? search = null, string[]? includeProperties = null);
        Task<Product> GetByAsync(Expression<Func<Product, bool>> filter, bool tracking = true);
        public Task<Product> DescendingIdAsync();
    }
}
