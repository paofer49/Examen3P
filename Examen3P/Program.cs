using Examen3P.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configura el DbContext con la conexon MySQL
builder.Services.AddDbContext<PeliculaContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ExamenDatabase"),
    new MySqlServerVersion(new Version(8, 0, 23))));//Reemplaza con tu versión de MySQL si es diferenet

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

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
