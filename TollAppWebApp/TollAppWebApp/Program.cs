using Microsoft.EntityFrameworkCore;
using TollAppWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); //Registers MVC controllers with the DI container

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register DbContext with the connection string
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TollContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); //allows controller endpoints to be recognized 
app.Run();


record MessageRequest(string Text);
