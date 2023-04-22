namespace ProductAPI.Service.Implementations
{
    public class BaseService<T,K>
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;
        protected readonly BaseResponse<K> _baseResponse;
        protected string message = "";
        public BaseService(IMapper mapper, ILogger<T> logger, BaseResponse<K> baseResponse)
        {
            _mapper= mapper;
            _logger= logger;
            _baseResponse= baseResponse;
        }
    }
}
