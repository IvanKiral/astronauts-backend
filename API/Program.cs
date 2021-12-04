using API.Configuration;
using API.Utils;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDependencies();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    Converters = new List<JsonConverter> { new CustomDateTimeConverter() }
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();