using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Personnel.Api.Apis;
using Personnel.Api.Data;

namespace Personnel.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
        builder.Services.AddDbContext<PersonnelDbContext>(cfg =>
        {
            cfg.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnectionString"),
                options =>
                {
                    options.EnableRetryOnFailure(3);
                    options.MigrationsAssembly(migrationsAssembly);
                });
        });
        builder.Services.AddAuthorization();

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

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGroup("/api/v1/member")
            .WithTags("Member API")
            .MapMemberApi();

        app.Run();
    }
}