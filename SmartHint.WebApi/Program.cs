using SmartHint.Domain.Context;
using SmartHint.Domain.Interfaces;
using SmartHint.Domain.Validations.Handles;
using SmartHint.Infrastruct.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IHandler, AbstractHandler>();
builder.Services.AddTransient<IEmailInUseHandler, EmailInUseHandler>();
builder.Services.AddTransient<IChainOfResponsibility, ChainOfResponsibility>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
