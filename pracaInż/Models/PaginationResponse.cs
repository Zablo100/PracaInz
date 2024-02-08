namespace pracaInż.Models
{
    public class PaginationResponse<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public T Value { get; set; }

        public PaginationResponse(int page, int totalCount, int pageSize, T value)
        {
            Page = page;
            TotalCount = totalCount;
            PageSize = pageSize;
            Value = value;
        }
    }
}
