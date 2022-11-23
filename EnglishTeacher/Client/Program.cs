using EnglishTeacher.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("oidc", options.ProviderOptions);
});

builder.Services.AddHttpClient("api", client => client.BaseAddress = new Uri("https://localhost:7168"))
    .AddHttpMessageHandler(sp =>
{
    var handler = sp.GetService<AuthorizationMessageHandler>()
        .ConfigureHandler(
            authorizedUrls: new[] { "https://localhost:7168" },
            scopes: new[] { "api1" });
    return handler;
});

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
