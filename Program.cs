using GymAPI.Infra.Database;
using GymAPI.Infra.Repositories;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Providers.Mapper;
using GymAPI.Providers.Mapper.Interfaces;
using GymAPI.Services;
using GymAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

builder.Services
    .AddDbContext<APIContext>(options => options
        .UseSqlServer(connectionString)
    );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IStudentMapper, StudentMapper>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingMapper, TrainingMapper>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------------------------------------------------------------- //

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
