﻿namespace api;

public class UserResponseDto
{   

    public Guid Id { get; set; }
    public string Email { get; set; }
    
    public ProfileResponseDto Profile { get; set; }

}
