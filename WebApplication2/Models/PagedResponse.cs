
namespace HardenCRUD.Models;

public class PagedResponse<T>
{
    public required IEnumerable<T> Data { get; set; }
    public required PaginationMeta Meta { get; set; }
}

public class PaginationMeta
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}
