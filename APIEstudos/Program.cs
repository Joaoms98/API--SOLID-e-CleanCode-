using APIEstudos.AutoMapper;
using APIEstudos.Data;
using APIEstudos.Handlers.Commands;
using APIEstudos.Interfaces;
using APIEstudos.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbBaseContext>
    (opt => opt.UseSqlServer
         ("Data Source=localhost;Initial Catalog=APITESTE66;Integrated Security=True"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(DomainProfileCore));

builder.Services.AddScoped<IUserCommand, CreateUserHandler>();
builder.Services.AddScoped<IUserService, ClienteServiceRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
