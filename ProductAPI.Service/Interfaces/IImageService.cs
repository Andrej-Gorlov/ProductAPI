namespace ProductAPI.Service.Interfaces
{
    public interface IImageService : IBaseService<ImageDTO>
    {
        Task<IBaseResponse<List<ImageDTO>>> GetServiceAsync(string? filter = null, string? search = null);
        Task<IBaseResponse<ImageDTO>> CreateServiceAsync(CreateImageDTO createModel);
        Task<IBaseResponse<ImageDTO>> UpdateServiceAsync(UpdateImageDTO updateModel);
    }
}
