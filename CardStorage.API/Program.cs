using BL.Services;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddSingleton<ICardRepository, CardRepository>();
builder.Services.AddTransient<ICardDeckService, CardDeckService>();
builder.Services.AddSingleton<ICardDeckRepository, CardDeckRepository>();

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
