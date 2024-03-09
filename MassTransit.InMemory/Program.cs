using MassTransit;
using MassTransit.InMemory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(cfg =>
{
    cfg.SetKebabCaseEndpointNameFormatter();
    cfg.AddConsumers(typeof(Program).Assembly);
    cfg.UsingInMemory((context, config) => config.ConfigureEndpoints(context));
});

builder.Services.AddHostedService<MessagePublisher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
