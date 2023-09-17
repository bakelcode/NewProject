using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewsProject.Client;
using NewsProject.Client.Authenticaions;
using NewsProject.Client.Services;
using NewsProject.Shared.Dtos;
using NewsProject.Shared.Dtos.Administrations;
using NewsProject.Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IMainService<Category>, MainService<Category>>();
builder.Services.AddScoped<IMainService<Barench>, MainService<Barench>>();
builder.Services.AddScoped<IMainService<Product>, MainService<Product>>();
builder.Services.AddScoped<IMainService<ProductDto>, MainService<ProductDto>>();
builder.Services.AddScoped<IMainService<Supplier>, MainService<Supplier>>();
builder.Services.AddScoped<IMainService<InvoiceTemp>, MainService<InvoiceTemp>>();
builder.Services.AddScoped<IMainService<Invoice>, MainService<Invoice>>();
builder.Services.AddScoped<IMainService<Invoicelist>, MainService<Invoicelist>>();
builder.Services.AddScoped<IMainService<RolesDto>, MainService<RolesDto>>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>();

await builder.Build().RunAsync();
