using AzureDemo.Controllers;
using AzureDemo.Data;
using AzureDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AzureDemoDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AzureDemoConnectionString")));

//builder.Services.AddSingleton(
//    provider =>
//    {
//        var configuration = provider.GetRequiredService<IConfiguration>();
//        string connectionString = configuration["ConnectionString"];
//        string queueName = "myqueue"; // Replace with your queue name
//        return new AzureQueueService(configuration);
//    });
builder.Services.AddSingleton<AzureQueueService>();
//builder.Services.AddTransient<CustomMiddleware>();


var app = builder.Build();
    

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
       

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
//app.UseMiddleware<CustomMiddleware>();

app.Run();
    