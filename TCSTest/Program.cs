using TcsTest.RepositoryLayer.Interfaces;
using TcsTest.RepositoryLayer.Repository;
using TcsTest.Utilities.Helpers;
using TcsTest.Utilities.Helpers.Interfaces;
using TCSTest.ServiceLayer.Interfaces;
using TCSTest.ServiceLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IJsonFileHelper, JsonFileHelper>();

builder.Services.AddScoped<IContentCatalogRepo, ContentCatalogRepo>();
builder.Services.AddScoped<IContentCatalogService, ContentCatalogService>();

builder.Services.AddScoped<IChannelRepo, ChannelRepo>();
builder.Services.AddScoped<IChannelService, ChannelService>();

builder.Services.AddScoped<IChannelScheduleRepo, ChannelScheduleRepo>();
builder.Services.AddScoped<IChannelScheduleService, ChannelScheduleService>();

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
