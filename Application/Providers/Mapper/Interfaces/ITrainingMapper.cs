using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

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
