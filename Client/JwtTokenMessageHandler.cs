using System.Net.Http.Headers;

public class JwtTokenMessageHandler : DelegatingHandler
{
    private readonly Uri _allowedBaseAddress;
    private readonly JwtAuthenticationStateProvider _loginStateService;

    public JwtTokenMessageHandler(Uri allowedBaseAddress, JwtAuthenticationStateProvider loginStateService)
    {
        this._allowedBaseAddress = allowedBaseAddress;
        this._loginStateService = loginStateService;
    }

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return this.SendAsync(request, cancellationToken).Result;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var uri = request.RequestUri;
        var isSelfApiAccess = this._allowedBaseAddress.IsBaseOf(uri);

        if (isSelfApiAccess)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this._loginStateService.Token ?? string.Empty);
        }

        return base.SendAsync(request, cancellationToken);
    }
}