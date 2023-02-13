namespace ProductAPI.DAL.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<BaseRepository<T>> _logger;
        internal DbSet<T> dbSet;
        public BaseRepository(ApplicationDbContext db, ILogger<BaseRepository<T>> logger)
        {
            _db = db;
            _logger = logger;
            this.dbSet = _db.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);  
            await SeveAsync();
            _logger.LogInformation("Сущность создана.");
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            _logger.LogInformation("Сущность удалена.");
            await SeveAsync();
        }

        public async Task<T> UpdateAsync(T entity, T carent)
        {
             _db.Entry(carent).CurrentValues.SetValues(entity);
            await SeveAsync();
            _logger.LogInformation("Сущность обновлена.");
            return entity;
        }
        /// <summary>
        /// Create to DB
        /// </summary>
        /// <returns></returns>
        private async Task SeveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
