namespace ProductAPI.Service.Interfaces
{
    public interface IProductService : IBaseService<ProductDTO>
    {
        Task<IBaseResponse<PagedList<ProductDTO>>> GetServiceAsync(PagingQueryParameters paging, string? filter = null, string? search = null);
        Task<IBaseResponse<ProductDTO>> CreateServiceAsync(CreateProductDTO createModel);
        Task<IBaseResponse<ProductDTO>> UpdateServiceAsync(UpdateProductDTO updateModel);
    }
}