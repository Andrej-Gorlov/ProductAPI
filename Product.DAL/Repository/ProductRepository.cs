namespace ProductAPI.DAL.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ApplicationDbContext db, ILogger<ProductRepository> logger) : base(db, logger)
        {
            _db = db;
            _logger = logger;
        } 

        public async Task<IEnumerable<Product>> GetAsync(Expression<Func<Product, bool>>? filter = null, string? search = null, string[]? includeProperties = null)
        {
            IQueryable<Product> products = _db.Products;
            if (includeProperties != null)
            {
                _logger.LogInformation($"включено свойство: {includeProperties}.");
                foreach (var item in includeProperties)
                {
                    products = products.Include(item);
                }
            }
            if (filter != null)
            {
                _logger.LogInformation($"Применен фильтр: {filter.Body},Type: {filter.Type}.");
                products = products.Where(filter);
            }
            if (search != null && includeProperties is null)
            {
                _logger.LogInformation($"Применен поиск: {search}.");
                products = products.Where(x => EF.Functions.Like(x.ProductName, $"%{search}%"));
            }
            if (search != null && includeProperties?.FirstOrDefault(x => x== nameof(ProductDTO.Category)) != null)
            {
                _logger.LogInformation($"Применен поиск: {search}.");
                products = products.Where(
                    x => EF.Functions.Like(x.ProductName, $"%{search}%")
                    || EF.Functions.Like(x.Category.CategoryName, $"%{search}%"));
            }
            _logger.LogInformation("Возвращение списка продуктов.");
            return await products.ToListAsync();
        }

        public async Task<Product> GetByAsync(Expression<Func<Product, bool>> filter, bool tracking = true)
        {
            IQueryable<Product> products = _db.Products;
            if (!tracking)
            {
                _logger.LogInformation($"Применен AsNoTracking. Данные не помещены в кэш");
                products = products.AsNoTracking();
            }
            _logger.LogInformation($"Возвращен отфильтрованный список. Filter: {filter.Body},Type: {filter.Type}.");
            return await products.Include(x=>x.Category).Include(x=>x.SecondaryImages).FirstOrDefaultAsync(filter);
        }
    }
}
