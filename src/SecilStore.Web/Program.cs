using Microsoft.EntityFrameworkCore;
using SecilStore.ApplicationCore.Interfaces;
using SecilStore.Infrastructure.Data;
using System.Reflection;

namespace SecilStore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<SecilStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddTransient(options => new ConfigurationService(connectionString, "configuration", "records"));

            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

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

            app.Run();
        }
    }
}
