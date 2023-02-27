namespace ProductAPI.Domain.Paging
{
    public class PagedList<T> : List<T>
    {
        public ParameterPagedList? Parameter { get; init; }
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Parameter = new(pageNumber, (int)Math.Ceiling(count / (double)pageSize), pageSize, count);
            AddRange(items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
