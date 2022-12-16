namespace ProductAPI.DAL.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>, IMinimalGetRepository<Category>
    {
    }
}
