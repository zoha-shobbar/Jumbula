namespace Jumbula.Application.Dtos.Jwt;
public class AccessToken
{
    public string Token { get; set; }
    public int ExpiresIn { get; set; }
}
