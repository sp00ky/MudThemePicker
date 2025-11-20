using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudThemePicker;
using MudThemePicker.WasmDemo.Client;
using MudThemePicker.WasmDemo.Client.Themes;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddMudThemePicker(typeof(DefaultTheme).Assembly);

await builder.Build().RunAsync();
