using BlazorServer.Models.DBContext;
using BlazorServer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// µù¥U¸ê®Æ®w
builder.Services.AddDbContext<DemoDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
);

// Add services to the container.
//builder.Services.AddHttpClient<Backen>
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<OrderService>();

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