using System.Linq;

namespace ProductAPI.DAL.Repository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        private readonly ApplicationDbContext _db;
        public ImageRepository(ApplicationDbContext db) : base(db) => _db = db;

        public async Task<IEnumerable<Image>> GetAsync(Expression<Func<Image, bool>>? filter = null, string? search = null)
        {
            IQueryable<Image> images = _db.Images;
            if (filter != null)
            {
                WatchLogger.Log($"Применен фильтр: {filter.Body},Type: {filter.Type}.");
                images = images.Where(filter);
            }
            if (search != null)
            {
                WatchLogger.Log($"Применен поиск: {search}.");
                images = images.Where(x => EF.Functions.Like(x.ImageUrl, $"%{search}%"));
            }
            WatchLogger.Log("Возвращение списка категорий.");
            return await images.ToListAsync();
        }

        public async Task<Image> GetByAsync(Expression<Func<Image, bool>> filter, bool tracking = true)
        {
            IQueryable<Image> images = _db.Images;
            if (!tracking)
            {
                WatchLogger.Log($"Применен AsNoTracking. Данные не помещены в кэш");
                images = images.AsNoTracking();
            }
            WatchLogger.Log($"Возвращен отфильтрованный список. Filter: {filter.Body},Type: {filter.Type}.");
            return await images.FirstOrDefaultAsync(filter);
        }
    }
}
