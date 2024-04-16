using Adapter.Database;
using DomainApi;
using DomainApi.Models;
using DomainImpl;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ApplicationDatabase"),
        new MySqlServerVersion(new Version(5, 7, 39))));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen();

builder.Services.AddResponseCaching();

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>(); 

builder.Services.AddLogging(build =>
{
    build.AddConsole().SetMinimumLevel(LogLevel.Debug);
    build.AddDebug().SetMinimumLevel(LogLevel.Debug);
});

var app = builder.Build();
app.UseResponseCaching();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    app.UseSwagger();

    app.UseSwaggerUI(
        options =>
        {
            var url = "/swagger/v1/swagger.json";
            options.SwaggerEndpoint(url, "User API");
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();