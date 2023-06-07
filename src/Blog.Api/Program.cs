using System.Reflection;
using Blog.Api.Data;
using Blog.Api.Helpers;
using Blog.Api.Mapping;
using Blog.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogContext>();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddTransient<IDateTimeProvider, DateTimeProvider>();
builder.Services.AddTransient<IPostRepository, PostRepository>();

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

app.MapControllers();

app.Run();