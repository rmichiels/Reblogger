using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using TumblrCache.Client;
using TumblrCache.Client.Helpers;
using TumblrCache.Shared.Handlers;
using TumblrCache.Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<HttpClientHelper>();
builder.Services.AddSingleton<TumblrClient>();
builder.Services.AddSingleton<ArchiveHandler>();

await builder.Build().RunAsync();
