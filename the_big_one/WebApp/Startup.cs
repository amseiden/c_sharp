namespace WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // Add controllers services
            // Add other services here, such as database contexts, authentication, etc.
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting(); // Enable routing

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map controllers
            });
        }
    }
}
