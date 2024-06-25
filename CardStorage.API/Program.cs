using BL.Services;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CardStorage API",
        Description = "CardStorage API",
    });
    var filePath = Path.Combine(AppContext.BaseDirectory, "CardStorage.API.xml");
    c.IncludeXmlComments(filePath);
});
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
