using MermaidJS.Blazor;
using MermaidJS.Blazor.Demo;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMermaidJS(options =>
{
    options.MaxTextSize = 100000;
    options.SecurityLevel = MermaidSecurityLevels.Loose;
});

await builder.Build().RunAsync();
