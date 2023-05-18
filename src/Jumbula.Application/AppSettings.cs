namespace Jumbula.Application;
public class AppSettings
{
    public JwtSettings JwtSettings { get; set; }
}

public class JwtSettings
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string EncryptKey { get; set; }
    public int ExpirationMinutes { get; set; }
}