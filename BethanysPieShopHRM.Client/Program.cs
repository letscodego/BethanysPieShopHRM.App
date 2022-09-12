using BethanysPieShopHRM.App;
using BethanysPieShopHRM.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseAddress = string.Empty;
var baseAddress = builder.HostEnvironment.BaseAddress;
if(baseAddress.Contains("localhos"))
    apiBaseAddress = builder.Configuration["ApiBaseAddress_dev"];
else
    apiBaseAddress = builder.Configuration["ApiBaseAddress_prod"];

//to be able to use the code for both blazor client-side or server-side, we need to use http factory instead of httpclient
//builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44338") });

builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = new Uri(apiBaseAddress));
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => client.BaseAddress = new Uri(apiBaseAddress));
builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client => client.BaseAddress = new Uri(apiBaseAddress));

await builder.Build().RunAsync();
