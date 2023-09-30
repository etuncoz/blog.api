using Blog.Api.Auth;
using Blog.Api.Helpers;
using Blog.Api.Mapping;
using Blog.Application;
using Blog.Infrastructure;
using Blog.Infrastructure.Common.Persistence;
using InfrastructureDependencyInjection = Blog.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

builder.Services
    .AddInfrastructure()
    .AddApplication();

builder.Services.AddScoped<ApiKeyAuthFilter>();

var app = builder.Build();

app.UseExceptionHandler();

using var scope = app.Services.CreateScope();
await InfrastructureDependencyInjection.InitializeDatabaseAsync(scope.ServiceProvider);

PostMapper.Configure(app.Services.GetService<IDateTimeProvider>()!);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseMiddleware<ValidationMappingMiddleware>();
app.MapControllers();

app.Run();