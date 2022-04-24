namespace BlazorJWT_Auth.Server.Requests
{
    public class LoginResponse
    {
        private bool v;
        private string jwt;

        public LoginResponse(bool v, string jwt)
        {
            this.v = v;
            this.jwt = jwt;
        }

        public static LoginResponse? Failed { get; internal set; }
    }
}