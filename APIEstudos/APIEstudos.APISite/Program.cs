using Microsoft.EntityFrameworkCore;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Automapper;
using APIEstudos.Domain.Handlers.Command;
using APIEstudos.Domain.Interfaces.Implements;
using APIEstudos.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

string mySqlConnection =
              builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<DbBaseContext>(opt =>
                opt.UseMySql(mySqlConnection,
                        ServerVersion.AutoDetect(mySqlConnection)));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(DomainProfileCore));
builder.Services.AddScoped<IUserCommand, UserHandler>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();