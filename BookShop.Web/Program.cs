using BookShop.DataLayer;
using BookShop.DataLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContextPool<BookShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")
//    ));
//builder.Services.AddHostedService<Worker>();
//builder.Services.AddOptions();
//builder.Services.AddOptions<DbContextOptions>();
builder.Services.AddDbContext<BookShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")
    ));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<BookShop.DataLayer.Services.IAuthorService, AuthorService>();

builder.Services.AddRazorPages();



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



app.UseAuthorization();

app.MapRazorPages();

//For Area
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapAreaControllerRoute(
        "admin",
        "admin",
        "Admin/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        "default", "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
