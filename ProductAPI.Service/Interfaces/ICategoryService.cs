namespace ProductAPI.Service.Interfaces
{
    public interface ICategoryService : IBaseService<CategoryDTO>
    {
        Task<IBaseResponse<List<CategoryDTO>>> GetServiceAsync(string? filter = null, string? search = null);
        Task<IBaseResponse<CategoryDTO>> CreateServiceAsync(CreateCategoryDTO createModel);
        Task<IBaseResponse<CategoryDTO>> UpdateServiceAsync(UpdateCategoryDTO updateModel);
    }
}
