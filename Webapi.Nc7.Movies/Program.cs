using Microsoft.EntityFrameworkCore;
using Webapi.Nc7.Movies.Data;
using Webapi.Nc7.Movies.MoviesMappers;
using Webapi.Nc7.Movies.Repository;
using Webapi.Nc7.Movies.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

//Configure the connection to SQL Server

builder.Services.AddDbContext<ApplicationDbContex>(option =>{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"));
});

// Add services to the container.
builder.Services.AddControllers();

// Add repositories
builder.Services.AddScoped<IRepositoryCategory,RepositoryCategory>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MovieMapper));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
