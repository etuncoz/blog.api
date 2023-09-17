using Blog.Api;
using Blog.Api.Data;
using Blog.Api.Helpers;
using Blog.Api.Mapping;
using Blog.Api.Repositories;
using FluentValidation;
using Serilog;
using Serilog.Formatting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogContext>();
builder.Services.AddTransient<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddTransient<IPostRepository, PostRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>(ServiceLifetime.Singleton);

// builder.Host.UseSerilog((context, configuration) => 
//     configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddMediatR((config) => config.RegisterServicesFromAssemblyContaining<IAssemblyMarker>());

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
PostMapper.Configure(app.Services.GetService<IDateTimeProvider>()!);
// Configure the HTTP request pipeline.
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