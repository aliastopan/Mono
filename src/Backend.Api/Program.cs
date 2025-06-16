using Scalar.AspNetCore;
using Serilog;
using Mono.Modules.Auth;

var builder = WebApplication.CreateBuilder(args);
var cfg = builder.Configuration;

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(cfg)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.AddEndpointDefinitions();
builder.Services.AddOpenApi();

builder.Services.AddAuthModule(cfg);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(option =>
    {
        option.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();
app.UseEndpointDefinitions();

app.Run();