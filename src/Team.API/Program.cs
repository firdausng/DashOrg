using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Team.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
builder.Services.AddDbContext<TeamDbContext>(cfg =>
{
    cfg.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString"),
        options =>
        {
            options.EnableRetryOnFailure(3);
            options.MigrationsAssembly(migrationsAssembly);
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();