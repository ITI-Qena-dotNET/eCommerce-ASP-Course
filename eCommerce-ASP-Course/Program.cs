using eCommerce.Application.Features.Products.DTOs;
using eCommerce.Infrastructure.Data;
using eCommerce_ASP_Course.Extensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextPool<AppDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(Assembly.GetCallingAssembly());
    c.RegisterServicesFromAssemblyContaining<GetAllProductsDTO>();
});

builder.Services.AddCors(c => c.AddDefaultPolicy(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

builder.Services.AddControllers()
    .AddNewtonsoftJson(o => o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
    .AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MigrateDatabase<AppDbContext>((context, services) =>
    {
        var logger = services.GetRequiredService<ILogger<AppDbContext>>();
        context.SeedAsync(logger);
    });

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
