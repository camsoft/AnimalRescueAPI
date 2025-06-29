using AnimalRescue.Data;
using AnimalRescue.Repositories;
using AnimalRescue.Repositories.Interfaces;
using AnimalRescue.Services;
using AnimalRescue.Services.Interfaces;
using AnimalRescueAPI.Providers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("corsPolicy", builder =>
{
    builder.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
}
));

builder.Configuration.AddVault(new VaultClient
{
    SecretsType = builder.Configuration["Vault:SecretsType"]
});

var dbBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));

dbBuilder.UserID = builder.Configuration["database:userID"];
dbBuilder.Password = builder.Configuration["database:password"];
dbBuilder.DataSource = builder.Configuration["database:server"];

builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"] = dbBuilder.ConnectionString;
builder.Services.AddDbContext<AnimalRescueDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IAnimalsService, AnimalsService>();
builder.Services.AddTransient<IAnimalsRepository, AnimalsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("corsPolicy");

app.MapControllers();

if (app.Environment.IsDevelopment())
    app.Run();
else
    app.Run("http://0.0.0.0.8080");
