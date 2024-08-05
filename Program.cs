using Microsoft.EntityFrameworkCore;
using AppraisalTracker.Modules.AppraisalActivity.Services;
using AppraisalTracker.Modules.Users.Service;
using AppraisalTracker.Data;
using AutoMapper;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var assemblies = new[] { typeof(Program).Assembly };
builder.Services.AddAutoMapper(assemblies);
builder.Services.AddScoped<IAppraisalActivityService, AppraisalActivityService>();
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IConfigMenuItemService, ConfigMenuItemService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AppraisalTracker API", Version = "v1" });
});

// Register CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("staffAppraisalTracker", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// Register DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppraisalTracker API v1");
    });
}

app.UseCors("staffAppraisalTracker");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
