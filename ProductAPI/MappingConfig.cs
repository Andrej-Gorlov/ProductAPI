namespace ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(x => {
                x.CreateMap<Category, CategoryDTO>().ReverseMap();
                x.CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
                x.CreateMap<Category, CreateCategoryDTO>().ReverseMap();

                x.CreateMap<Image, ImageDTO>().ReverseMap();
                x.CreateMap<Image, UpdateImageDTO>().ReverseMap();
                x.CreateMap<Image, CreateImageDTO>().ReverseMap();

                x.CreateMap<Product, ProductDTO>().ReverseMap();
                x.CreateMap<Product, UpdateProductDTO>().ReverseMap();
                x.CreateMap<Product, CreateProductDTO>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
