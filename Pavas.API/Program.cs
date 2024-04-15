using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Pavas.Abstractions.Authentication;
using Pavas.Abstractions.DatabaseContext;
using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands;
using Pavas.Abstractions.Dispatch.Queries;
using Pavas.API.MinimalApi;
using Pavas.Application.Mappers;
using Pavas.Infrastructure.Repository.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpoints();
builder.Logging.ClearProviders();

builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
builder.Services.AddDbContext<BaseContext, DatabaseContext>((services, options) =>
{
    options.UseNpgsql(services.GetService<IConfiguration>()?.GetConnectionString("Default"));
});

builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddApplicationMapper();
builder.Services.AddAuthContextServices();
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

app.UseAuthContextMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();
// app.UseHttpsRedirection();
app.Run();