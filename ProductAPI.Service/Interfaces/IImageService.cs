namespace ProductAPI.Service.Interfaces
{
    public interface IImageService
    {
        Task<IBaseResponse<List<ImageDTO>>> GetServiceAsync(string? filter = null, string? search = null);
        Task<IBaseResponse<ImageDTO>> CreateServiceAsync(CreateImageDTO createModel);
        Task<IBaseResponse<ImageDTO>> UpdateServiceAsync(UpdateImageDTO updateModel);
        Task<IBaseResponse<ImageDTO>> GetByIdServiceAsync(string id);
        Task<IBaseResponse<bool>> DeleteServiceAsync(string id);
    }
}
