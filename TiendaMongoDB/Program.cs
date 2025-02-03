using MongoDB.Driver;
using TiendaMongo.Data;
using TiendaMongo.Data.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//string conn = Environment.GetEnvironmentVariable("ConnectionString") ?? "";
//string db = Environment.GetEnvironmentVariable("DatabaseName") ?? "";
//MongoConfiguration mongoConfiguration = new MongoConfiguration(conn, db);

builder.Services.Configure<MongoConfiguration>(builder.Configuration.GetSection("MongoSettings"));

builder.Services.AddSingleton((sp =>
{
    var config = sp.GetRequiredService<IOptions<MongoConfiguration>>().Value;
    return new MongoClient(config.Connection);
}));
//builder.Services.AddSingleton(mongoConfiguration);
builder.Services.AddScoped<UserServices>();

var app = builder.Build();

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
