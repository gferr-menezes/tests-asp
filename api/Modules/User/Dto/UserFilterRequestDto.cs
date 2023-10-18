using Microsoft.AspNetCore.Mvc;

public class UserFilterRequestDto
{   
    [FromQuery]
    public string Input { get; set; }
}
