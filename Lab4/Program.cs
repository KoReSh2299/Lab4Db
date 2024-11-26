using Lab4.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("CachingProfile",
                    new Microsoft.AspNetCore.Mvc.CacheProfile()
                    {
                        Duration = 254,
                        Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any
                    });

                options.CacheProfiles.Add("NoCachingProfile",
                    new Microsoft.AspNetCore.Mvc.CacheProfile()
                    {
                        NoStore = true,
                        Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.None
                    });
            });
            var services = builder.Services;

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Lab4DbContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<Lab4DbContext>();
                DbInitializer.Initialize(dbContext);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
