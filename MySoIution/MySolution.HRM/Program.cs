using MySolution.BusinessLayers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

string connectionString = builder.Configuration.GetConnectionString("HRM") ?? "";
HRMService.Initialize(connectionString);


app.Run();
//B?n ch?t là main c?a ?ng d?ng web ASP.NET Core
//Thu?t ng? là  => Entry Point (?i?m ??u vào c?a ?ng d?ng)