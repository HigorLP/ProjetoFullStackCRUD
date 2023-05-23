global using ProjetoFullStackCRUD.Server.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjetoFullStackCRUD.Client;
using ProjetoFullStackCRUD.Client.Services.SuperHeroService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();

await builder.Build().RunAsync();
