namespace ProductAPI.Service.Interfaces
{
    public interface IBaseService<T>
    {
        Task<IBaseResponse<T>> GetByIdServiceAsync(int id);
        Task<IBaseResponse<bool>> DeleteServiceAsync(int id);
    }
}
