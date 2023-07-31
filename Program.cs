using Microsoft.EntityFrameworkCore;
using Resume_Managment_Wep_API.Core.AutoMapperConfig;
using Resume_Managment_Wep_API.Core.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Db Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnectionString"));
}
);

//Automapper Confg
builder.Services.AddAutoMapper(typeof(AutomapperConfigProfile));



builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
