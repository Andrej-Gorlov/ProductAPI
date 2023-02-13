namespace ProductAPI.DAL.Repository
{
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(ApplicationDbContext db, ILogger<CategoryRepository> logger) : base(db, logger)
        {
            _db = db;
            _logger = logger;
        } 

        public async Task<IEnumerable<Category>> GetAsync(Expression<Func<Category, bool>>? filter = null, string? search = null)
        {
            IQueryable<Category> categories = _db.Categorys;
            if (filter != null)
            {
                _logger.LogInformation($"Применен фильтр: {filter.Body},Type: {filter.Type}.");
                categories = categories.Where(filter);
            }
            if (search != null)
            {
                _logger.LogInformation($"Применен поиск: {search}.");
                categories = categories.Where(
                    x => EF.Functions.Like(x.CategoryName, $"%{search}%")
                    || EF.Functions.Like(x.ImageUrl, $"%{search}%"));
            }
            _logger.LogInformation("Возвращение списка категорий.");
            return await categories.ToListAsync();
        }

        public async Task<Category> GetByAsync(Expression<Func<Category, bool>> filter, bool tracking = true)
        {
            IQueryable<Category> categorys = _db.Categorys;
            if (!tracking)
            {
                _logger.LogInformation($"Применен AsNoTracking. Данные не помещены в кэш");
                categorys = categorys.AsNoTracking();
            }
            _logger.LogInformation($"Возвращен отфильтрованный список. Filter: {filter.Body},Type: {filter.Type}.");
            return await categorys.FirstOrDefaultAsync(filter);
        }
    }
}
