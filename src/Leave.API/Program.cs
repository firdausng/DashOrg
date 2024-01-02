using Leave.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
builder.Services.AddDbContext<LeaveDbContext>(cfg =>
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
builder.Services.AddSwaggerGen();

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
