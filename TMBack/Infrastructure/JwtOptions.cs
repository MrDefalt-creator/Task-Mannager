﻿namespace TMBack.Infrastructure;

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    
    
    public int ExpiresIn { get; set; }
}