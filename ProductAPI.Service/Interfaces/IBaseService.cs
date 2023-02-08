namespace ProductAPI.Service.Interfaces
{
    public interface IBaseService<T> where T : struct
    {
        Task<IBaseResponse<T>> GetByIdServiceAsync(int id);
        Task<IBaseResponse<bool>> DeleteServiceAsync(int id);
    }
}
