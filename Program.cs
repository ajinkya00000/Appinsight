
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string instrumentationKey = "d8d6e682-1547-4d46-bcab-edf207775e6d";
builder.Services.AddSingleton<TelemetryClient>(new TelemetryClient(new TelemetryConfiguration(instrumentationKey)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
  // app.usepr
}
//



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
