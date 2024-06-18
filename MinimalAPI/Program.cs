using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data.Context;
using MinimalAPI.Data.Repositories;
using MinimalAPI.Interfaces;
using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MinimalAPIContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ICustomerFieldService, CustomerFieldService>();
builder.Services.AddScoped<ICustomerFieldValueService, CustomerFieldValueService>();
builder.Services.AddScoped<ICustomerFieldValueHistoryService, CustomerFieldValueHistoryService>();

builder.Services.AddScoped<ICustomerFieldRepository, CustomerFieldRepository>();
builder.Services.AddScoped<ICustomerFieldValueRepository, CustomerFieldValueRepository>();
builder.Services.AddScoped<ICustomerFieldValueHistoryRepository, CustomerFieldValueHistoryRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
