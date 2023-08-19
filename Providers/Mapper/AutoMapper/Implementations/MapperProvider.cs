using GymAPI.Providers.Mapper.Interfaces;

namespace GymAPI.Providers.Mapper.AutoMapper.Implementations;

public class MapperProvider : IMapperProvider
{
    public IStudentMapper StudentMapper { get; init;}
    public ITrainingMapper TrainingMapper { get; init;}
    public IExerciseMapper ExerciseMapper { get; init;}

    public MapperProvider(
        IStudentMapper studentMapper, 
        ITrainingMapper trainingMapper, 
        IExerciseMapper exerciseMapper
    )
    {
        StudentMapper = studentMapper;
        TrainingMapper = trainingMapper;
        ExerciseMapper = exerciseMapper;
    }
}
