namespace ProductAPI.DAL.Repository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ImageRepository> _logger;
        public ImageRepository(ApplicationDbContext db, ILogger<ImageRepository> logger) : base(db, logger)
        {
            _db = db;
            _logger = logger;
        } 

        public async Task<IEnumerable<Image>> GetAsync(Expression<Func<Image, bool>>? filter = null, string? search = null)
        {
            IQueryable<Image> images = _db.Images;
            if (filter != null)
            {
                _logger.LogInformation($"Применен фильтр: {filter.Body},Type: {filter.Type}.");
                images = images.Where(filter);
            }
            if (search != null)
            {
                _logger.LogInformation($"Применен поиск: {search}.");
                images = images.Where(x => EF.Functions.Like(x.ImageUrl, $"%{search}%"));
            }
            _logger.LogInformation("Возвращение списка категорий.");
            return await images.ToListAsync();
        }

        public async Task<Image> GetByAsync(Expression<Func<Image, bool>> filter, bool tracking = true)
        {
            IQueryable<Image> images = _db.Images;
            if (!tracking)
            {
                _logger.LogInformation($"Применен AsNoTracking. Данные не помещены в кэш");
                images = images.AsNoTracking();
            }
            _logger.LogInformation($"Возвращен отфильтрованный список. Filter: {filter.Body},Type: {filter.Type}.");
            return await images.FirstOrDefaultAsync(filter);
        }
    }
}
