namespace BlazorJWT_Auth.Server.Requests
{
    public class RegisterResponse
    {
        private object succeeded;

        public RegisterResponse(object succeeded)
        {
            this.succeeded = succeeded;
        }
    }
}