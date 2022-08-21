using Microsoft.EntityFrameworkCore;
using APIEstudos.Domain.Interfaces;
using APIEstudos.Domain.Automapper;
using APIEstudos.Domain.Handlers.Command;
using APIEstudos.Domain.Interfaces.Implements;
using APIEstudos.Infrastructure;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DbBaseContext>
    (opt => opt.UseSqlServer
         ("Data Source=localhost;Initial Catalog=APITESTE66;Integrated Security=True"));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(DomainProfileCore));

builder.Services.AddScoped<IUserCommand, CreateUserHandler>();
builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
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