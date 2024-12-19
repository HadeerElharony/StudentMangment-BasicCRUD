using System;
using System.Reflection;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Test.BAL.Interfaces;
using Test.BAL.Services;
using Test.DAL.Interfaces;
using Test.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var clientURL = builder.Configuration.GetValue<string>("clientURL");

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.WithOrigins(clientURL) // Allow specific origins
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Set the Swagger document title and version
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Test API",
        Version = "v1",
        Description = "API documentation for the Test project"
    });

    // Add XML comments to Swagger to display the summary from your code
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<Test.DAL.DbContext.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register Repositories
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//builder.Services.AddScoped<ICourseRepository, CourseRepository>();
//builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();

// Register Services
builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddScoped<ICourseService, CourseService>();
//builder.Services.AddScoped<IStudentCourseService, StudentCourseService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   app.UseSwaggerUI();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
