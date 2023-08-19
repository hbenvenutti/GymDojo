namespace GymAPI.Providers.Mapper.Interfaces;

public interface IMapperProvider
{
    IStudentMapper StudentMapper { get; init; }
    ITrainingMapper TrainingMapper { get; init; }
    IExerciseMapper ExerciseMapper { get; init; }
}
