using Microsoft.AspNetCore.Mvc;

public class PaginationRequest {
    [FromQuery]
    public int Page { get; set; }
    
    [FromQuery]
    public int PerPage { get; set; }
    
    [FromQuery]
    public string SortBy { get; set; }

    [FromQuery]
    public string SortDirection { get; set; }
}