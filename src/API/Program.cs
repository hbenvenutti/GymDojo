using GymDojo.Bootstrap.Database;
using GymDojo.Infra.Repositories;
using GymDojo.Infra.Repositories.Interfaces;
using GymDojo.Providers.Mapper.AutoMapper.Implementations;
using GymDojo.Providers.Mapper.Interfaces;
using GymDojo.Services;
using GymDojo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

DatabaseStarter.Start(builder.Services, builder.Configuration);

// builder.Services
//     .AddDbContext<APIContext>(options => options
//         .UseSqlServer(connectionString)
//     );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IStudentMapper, StudentMapper>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingMapper, TrainingMapper>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();

builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseMapper, ExerciseMapper>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

builder.Services.AddScoped<IMapperProvider, MapperProvider>();

builder.Services.AddControllers();

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
