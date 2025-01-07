using Microsoft.EntityFrameworkCore;
using TTADotNetCore.Database.Models;
using TTADotNetCore.Domain.Features.Blog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//UI -3 presentation layer
//Bl -2 Business Logic
//DA -1 Data Access

builder.Services.AddScoped<IBlogService, BlogV2Service>();
//builder.Services.AddScoped<BlogService>();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));

},ServiceLifetime.Transient,ServiceLifetime.Transient);

//builder.Services.AddScoped<IBlogService,BlogService>();
//builder.Services.AddScoped<IBlogService, BlogV2Service>();

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
