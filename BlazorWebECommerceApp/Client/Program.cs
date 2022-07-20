global using BlazorWebECommerceApp.Shared;
global using System.Net.Http.Json;
global using BlazorWebECommerceApp.Client.Services.ProductService;
global using BlazorWebECommerceApp.Client.Services.CategoryService;
global using BlazorWebECommerceApp.Client.Services.CartService;
global using BlazorWebECommerceApp.Client.Services.AuthService;
global using BlazorWebECommerceApp.Client.Services.OrderService;
global using BlazorWebECommerceApp.Client.Services.AddressService;
global using Microsoft.AspNetCore.Components.Authorization;
using BlazorWebECommerceApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAdressService, AddressService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
