using DevBlog.API.Clients;
using DevBlog.API.Clients.Contracts;
using DevBlog.API.Data;
using DevBlog.API.Services;
using DevBlog.API.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevBlogConnectionString"));
});

builder.Services.AddControllers();

builder.Services.AddScoped<IDevBlogService, DevBlogService>();

builder.Services.AddScoped<IDevBlogClient, DevBlogClient>();

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
