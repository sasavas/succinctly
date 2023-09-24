using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureDependencies();

var app = builder.Build();

app.UseCors();

app.Run();