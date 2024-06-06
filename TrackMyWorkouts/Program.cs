using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrackMyWorkouts.Data;
using TrackMyWorkouts.Data.DataModels;
using TrackMyWorkouts.Services.Implementations;
using TrackMyWorkouts.Services.Interfaces;

namespace TrackMyWorkouts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          
            builder.Services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"])
                .EnableSensitiveDataLogging(true));

          
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            builder.Services.AddCascadingAuthenticationState();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddScoped<SignInManager<ApplicationUser>>();
            builder.Services.AddScoped<UserManager<ApplicationUser>>();
            builder.Services.AddTransient<IEmailService, EmailService>();



            //application services
            builder.Services.AddScoped<IExercise, Exercise>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                StaticWebAssetsLoader.UseStaticWebAssets(app.Environment, app.Configuration);
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //automatically applies pending migration on startup
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "An error occurred while applying migrations.");
                }
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapFallbackToPage("/_Host");
            app.MapBlazorHub();
            app.MapRazorPages();
            
            app.Run();
        }
    }
}