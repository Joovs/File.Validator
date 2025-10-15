using File.Validator.Presentation.Modules;
using File.Validator.Application;
using File.Validator.Infrastructure;
using File.Validator.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("TestDataBase");
    options.UseSqlServer(connectionString);
});
builder.Services.AddScoped<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1");
    });
}

ModulesConfiguration.Configure(app);

app.UseHttpsRedirection();

app.Run();
