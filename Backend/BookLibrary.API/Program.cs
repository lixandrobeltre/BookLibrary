using BookLibrary.API.Controllers;
using BookLibrary.API.Data;
using BookLibrary.API.Interfaces;
using BookLibrary.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BLContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("BLDbConnection")));
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var FE_CORS = "fe_cors_local"; //for testing FE local

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: FE_CORS,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(FE_CORS);

app.UseHttpsRedirection();

app.MapBookEndpoints();

app.Run();
