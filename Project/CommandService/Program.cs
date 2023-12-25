using CommandService.AsyncDataServices;
using CommandService.Data;
using CommandService.EventProcessing;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("InMemorry"));

builder.Services.AddScoped<ICommandRepo, CommandRepo>();
builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
builder.Services.AddHostedService<MessageBusSubscriber>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
