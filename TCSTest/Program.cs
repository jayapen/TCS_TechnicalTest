
using TCSTest.Repository.Implementation;
using TCSTest.Repository.Interfaces;
using TCSTest.Services.Implementation;
using TCSTest.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICatalogRepository, ContentCatalogRepo>();
builder.Services.AddScoped<ICatalogService, ContentCatalogService>();

builder.Services.AddScoped<IChannelRepository, ChannelRepo>();
builder.Services.AddScoped<IChannelService, ChannelService>();

builder.Services.AddScoped<ISchedulerRepository, ChannelSchedulerRepo>();
builder.Services.AddScoped<ISchedulerService, ChannelSchedulerService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
