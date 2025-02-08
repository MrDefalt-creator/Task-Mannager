namespace TMBack.Infrastructure;

public class JwtOptions
{
    public string SecretKey { get; set; } = "TM_Backend_Secret_Key_For_Testing_Only";
    
    
    public int ExpiresIn { get; set; }
}