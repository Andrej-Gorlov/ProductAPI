namespace ProductAPI.Domain.Paging
{
    public class ParameterPagedList
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

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
