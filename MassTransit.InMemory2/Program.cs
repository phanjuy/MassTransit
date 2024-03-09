using MassTransit.InMemory2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<PingPublisher>();

var app = builder.Build();

app.Run();
