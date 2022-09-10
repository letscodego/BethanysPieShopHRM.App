using BethanysPieShopHRM.App.Services;


var builder = WebApplication.CreateBuilder(args);
var apiBaseAddress = builder.Configuration["ApiBaseAddress"];

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = new Uri(apiBaseAddress));
builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => client.BaseAddress = new Uri(apiBaseAddress));
builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client => client.BaseAddress = new Uri(apiBaseAddress));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
