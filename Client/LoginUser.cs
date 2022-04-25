using System.Security.Claims;

internal class LoginUser
{
    internal ClaimsPrincipal claimsPrincipal;
    
    private object name;
    private object principal;

    public string DisplayName { get; internal set; }
    public string Jwt { get; internal set; }
    
    public LoginUser(object name, string jwt, object principal)
    {
        this.name = name;
        Jwt = jwt;
        this.principal = principal;
    }
}