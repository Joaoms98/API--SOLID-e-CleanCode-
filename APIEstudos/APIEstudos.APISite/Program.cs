using Microsoft.EntityFrameworkCore;
using MediatR;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Automapper;
using APIEstudos.Infrastructure;
using APIEstudos.Domain.Interfaces.Implements;

var builder = WebApplication.CreateBuilder(args);

string mySqlConnection =
              builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<DbBaseContext>(opt =>
                opt.UseMySql(mySqlConnection,
                        ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(DomainProfileCore));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();