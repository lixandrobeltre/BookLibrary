using BookLibrary.API.Controllers;
using BookLibrary.API.Data;
using BookLibrary.API.Interfaces;
using BookLibrary.API.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var connectionStringBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("BLDbConnection"))
{
    UserID = builder.Configuration["bl_db_user"],
    Password = builder.Configuration["bl_db_pass"]
};

builder.Services.AddDbContext<BLContext>(op => op.UseSqlServer(connectionStringBuilder.ConnectionString));
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddEndpointsApiExplorer();

var dbUser = Environment.GetEnvironmentVariable("bl_db_user");

//builder.Configuration.AddUserSecrets<Program>();

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

app.UseCors(FE_CORS);

app.UseHttpsRedirection();

app.MapBookEndpoints();

app.Run();
