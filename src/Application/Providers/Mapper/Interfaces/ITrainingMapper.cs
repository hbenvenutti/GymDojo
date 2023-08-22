using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Models;

namespace GymDojo.Providers.Mapper.Interfaces;

public interface ITrainingMapper : 
    IModelMapper<
        Training, 
        CreateTrainingDto, 
        UpdateTrainingDto, 
        IReadTrainingDto, 
        ReadTrainingDto
    >
{
    IReadTrainingDto ToReadDtoWithRelations(Training training);
    ICollection<ReadTrainingDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Training> trainings
    );
}
