using BookLibrary.API.Controllers;
using BookLibrary.API.Data;
using BookLibrary.API.Interfaces;
using BookLibrary.API.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string CORS_POLICY_NAME = "ClientCorsPolicy";

var connectionStringBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("BLDbConnection"))
{
    UserID = builder.Configuration["bl_db_user"],
    Password = builder.Configuration["bl_db_pass"]
};

builder.Services.AddDbContext<BLContext>(op => op.UseSqlServer(connectionStringBuilder.ConnectionString));
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddEndpointsApiExplorer();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS_POLICY_NAME, policy =>
    {
        policy.WithOrigins(allowedOrigins!)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(CORS_POLICY_NAME);

app.UseHttpsRedirection();

app.MapBookEndpoints();

app.Run();
