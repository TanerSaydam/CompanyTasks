using Microsoft.EntityFrameworkCore;
using RehberWebApi.Models.Context;
using RehberWebApi.Models.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RehberDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Add services to the container.

builder.Services.AddControllers();
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
