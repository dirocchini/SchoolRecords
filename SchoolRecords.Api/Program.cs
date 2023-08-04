using Microsoft.EntityFrameworkCore;
using SchoolRecords.ApplicationServices;
using SchoolRecords.ApplicationServices.AutoMapper;
using SchoolRecords.Infrasctructure.Data;
using SchoolRecords.Infrasctructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.AddDbContextFactory<SchoolRecordsContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

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
