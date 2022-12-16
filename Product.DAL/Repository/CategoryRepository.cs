namespace ProductAPI.DAL.Repository
{
    public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) => _db = db;

        public async Task<IEnumerable<Category>> GetAsync(Expression<Func<Category, bool>>? filter = null, string? search = null)
        {
            IQueryable<Category> categories = _db.Categorys;
            if (filter != null)
            {
                WatchLogger.Log($"Применен фильтр: {filter.Body},Type: {filter.Type}.");
                categories = categories.Where(filter);
            }
            if (search != null)
            {
                WatchLogger.Log($"Применен поиск: {search}.");
                categories = categories.Where(
                    x => EF.Functions.Like(x.CategoryName, $"%{search}%")
                    || EF.Functions.Like(x.ImageUrl, $"%{search}%"));
            }
            WatchLogger.Log("Возвращение списка категорий.");
            return await categories.ToListAsync();
        }

        public async Task<Category> GetByAsync(Expression<Func<Category, bool>> filter, bool tracking = true)
        {
            IQueryable<Category> categorys = _db.Categorys;
            if (!tracking)
            {
                WatchLogger.Log($"Применен AsNoTracking. Данные не помещены в кэш");
                categorys = categorys.AsNoTracking();
            }
            WatchLogger.Log($"Возвращен отфильтрованный список. Filter: {filter.Body},Type: {filter.Type}.");
            return await categorys.FirstOrDefaultAsync(filter);
        }
    }
}
