public class PaginationResponse<T>
{
    public List<T> Data { get; set; }

    public int Page { get; set; }

    public int Total { get; set; }

    public int PerPage { get; set; }

    public int TotalPages => (int)Math.Ceiling((double)Total / PerPage);
}
