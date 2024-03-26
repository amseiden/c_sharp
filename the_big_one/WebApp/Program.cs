using Adapter.Database;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(5, 7, 39))));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning()
    .AddMvc()
    .AddApiExplorer(
        options =>
        {
            // format the version as "'v'major[.minor][-status]"
            // ReSharper disable once StringLiteralTypo
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = false;
        });

builder.Services.AddSwaggerGen();

builder.Services.AddResponseCaching();

// builder.Services.AddScoped<IEngineService, EngineService>();

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
            foreach (var description in app.DescribeApiVersions())
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var name = description.GroupName;
                options.SwaggerEndpoint(url, name);
            }
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();