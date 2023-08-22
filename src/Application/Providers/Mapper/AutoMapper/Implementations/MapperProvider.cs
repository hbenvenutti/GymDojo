using GymDojo.Providers.Mapper.Interfaces;

namespace GymDojo.Providers.Mapper.AutoMapper.Implementations;

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
