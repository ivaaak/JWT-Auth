namespace BlazorJWT_Auth.Server.Requests
{
    public class LoginRequest
    {
        public string? Email { get; internal set; }
        public string? Password { get; internal set; }
    }
}