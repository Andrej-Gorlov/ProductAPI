namespace ProductAPI.Domain.Paging
{
    public record struct ParameterPagedList
    {
        public int CurrentPage { get; init ; }
        public int TotalPages { get; init ; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }

        public bool HasPrevious;
        public bool HasNext;
        public ParameterPagedList(int currentPage, int totalPages, int pageSize, int totalCount)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalCount = totalCount;
            HasPrevious = CurrentPage > 1;
            HasNext = CurrentPage < totalPages;
        }
    }
}
