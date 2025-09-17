var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews()
//     .AddCookieTempDataProvider();  // registered cookie based tempdata provider

builder.Services.AddControllersWithViews()
     .AddSessionStateTempDataProvider();  // registered cookie based tempdata provider

builder.Services.AddSession(); // session dependency added

builder.Services.AddMemoryCache(); // registering in memory chache dependency

builder.Services.AddResponseCaching();  // regestering dependency of response cache

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession(); // registering session middleware


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseResponseCaching();   // response cache in middle ware

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
