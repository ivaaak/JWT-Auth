namespace BlazorJWT_Auth.Server.Requests
{
    public class RegisterRequest
    {
        public string? EmailAddress { get; internal set; }
        public string? DisplayName { get; internal set; }
        public string? Password { get; internal set; }
    }
}