using BlazorJWT_Auth.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();

builder.Services.AddSingleton<JwtAuthenticationStateProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider>(provider => provider.GetRequiredService<JwtAuthenticationStateProvider>());

var appUri = new Uri(builder.HostEnvironment.BaseAddress);
builder.Services.AddScoped(provider => new JwtTokenMessageHandler(appUri, provider.GetRequiredService<JwtAuthenticationStateProvider>()));
builder.Services.AddHttpClient("MyApp.ServerAPI", client => client.BaseAddress = appUri)
    .AddHttpMessageHandler<JwtTokenMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyApp.ServerAPI"));


await builder.Build().RunAsync();



