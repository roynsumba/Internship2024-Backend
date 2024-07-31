using Microsoft.EntityFrameworkCore;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using AppraisalTracker.Data;
using AppraisalTracker.Extensions;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var assemblies = new[] { typeof(Program).Assembly };
builder.ConfigureAutoMapper(assemblies);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IAppraisalActivityService, AppraisalActivityService>();
builder.Services.AddScoped<IConfigMenuItemService, ConfigMenuItemService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Register DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

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



