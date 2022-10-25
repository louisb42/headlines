using headline.ui.blazor.web;
using headline.ui.blazor.web.Data;
using headline.ui.blazor.web.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IHeadlineMaintenanceViewModel, HeadlineMaintenanceViewModel>();
builder.Services.AddSingleton<IJSInProcessRuntime>(services => (IJSInProcessRuntime)services.GetRequiredService<IJSRuntime>());
builder.Services.AddScoped<IHeadlineData, HeadlineData>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
