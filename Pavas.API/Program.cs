using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Pavas.Abstractions.Authentication;
using Pavas.Abstractions.DatabaseContext;
using Pavas.Abstractions.DatabaseContext.Contracts;
using Pavas.Abstractions.Dispatch.Commands;
using Pavas.Abstractions.Dispatch.Queries;
using Pavas.API.MinimalApi;
using Pavas.Infrastructure.Repository.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpoints();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

builder.Services.AddDbContext<BaseContext, DatabaseContext>((services, options) =>
{
    options.UseNpgsql(services.GetService<IConfiguration>()?.GetConnectionString("Default"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddCommands();
builder.Services.AddQueries();
builder.Services.AddAuthContextServices();
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

app.UseAuthContextMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.MapEndpoints();
// app.UseHttpsRedirection();´
app.Run();