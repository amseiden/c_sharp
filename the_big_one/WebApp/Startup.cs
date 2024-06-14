using Adapter.Database;
using DomainApi;
using DomainImpl;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); 
            services.AddRazorPages(); 
            services.AddDbContext<UserDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("ApplicationDatabase"),
                    new MySqlServerVersion(new Version(8, 3, 0))));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen();
            services.AddResponseCaching();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddLogging(build =>
            {
                build.AddConsole().SetMinimumLevel(LogLevel.Debug);
                build.AddDebug().SetMinimumLevel(LogLevel.Debug);
            });

        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
                endpoints.MapRazorPages(); 
            });
        }
    }
}