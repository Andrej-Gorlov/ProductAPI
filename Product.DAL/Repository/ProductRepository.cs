using ProductAPI.Domain.Entity.ProductDTO;

namespace ProductAPI.DAL.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) => _db = db;

        public async Task<IEnumerable<Product>> GetAsync(Expression<Func<Product, bool>>? filter = null, string? search = null, string[]? includeProperties = null)
        {
            IQueryable<Product> products = _db.Products;
            if (includeProperties != null)
            {
                WatchLogger.Log($"включено свойство: {includeProperties}.");
                foreach (var item in includeProperties)
                {
                    products = products.Include(item);
                }
            }
            if (filter != null)
            {
                WatchLogger.Log($"Применен фильтр: {filter.Body},Type: {filter.Type}.");
                products = products.Where(filter);
            }
            if (search != null && includeProperties is null)
            {
                WatchLogger.Log($"Применен поиск: {search}.");
                products = products.Where(x => EF.Functions.Like(x.ProductName, $"%{search}%"));
            }
            if (search != null && includeProperties?.FirstOrDefault(x => x== nameof(ProductDTO.Category)) != null)
            {
                WatchLogger.Log($"Применен поиск: {search}.");
                products = products.Where(
                    x => EF.Functions.Like(x.ProductName, $"%{search}%")
                    || EF.Functions.Like(x.Category.CategoryName, $"%{search}%"));
            }
            WatchLogger.Log("Возвращение списка продуктов.");
            return await products.ToListAsync();
        }

        public async Task<Product> GetByAsync(Expression<Func<Product, bool>> filter, bool tracking = true)
        {
            IQueryable<Product> products = _db.Products;
            if (!tracking)
            {
                WatchLogger.Log($"Применен AsNoTracking. Данные не помещены в кэш");
                products = products.AsNoTracking();
            }
            WatchLogger.Log($"Возвращен отфильтрованный список. Filter: {filter.Body},Type: {filter.Type}.");
            return await products.Include(x=>x.Category). FirstOrDefaultAsync(filter);
        }

        public async Task<Product> DescendingIdAsync()
        {
            IQueryable<Product> product = _db.Products.OrderByDescending(x => x.ProductId);
            return await product.FirstOrDefaultAsync();
        }
    }
}
