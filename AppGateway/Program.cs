using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;

var builder = WebApplication.CreateBuilder(args);

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration.AddJsonFile($"ocelot.{env}.json");
builder.Services.AddOcelot();

var app = builder.Build();
app.UseRouting();
app.MapControllers();
await app.UseOcelot();

app.Run();
