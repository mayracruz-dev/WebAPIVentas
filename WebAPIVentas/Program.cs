using Microsoft.EntityFrameworkCore;
using WebAPIVentas.Models;
using Wkhtmltopdf.NetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBVENTAContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

builder.Services.AddControllers();
builder.Services.AddWkhtmltopdf("wkhtmltopdf/windows/wkhtmltopdf.exe");



var misReglaCors = "ReglaCors";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: misReglaCors, builder => {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(misReglaCors);

app.UseAuthorization();

app.MapControllers();

/*IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotative/Windows");*/

app.Run();
