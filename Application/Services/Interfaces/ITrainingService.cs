using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Services.Interfaces;

public interface ITrainingService :
    IModelService<
        Training,
        CreateTrainingDto,
        UpdateTrainingDto,
        IReadTrainingDto,
        ReadTrainingDtoWithRelations
    >
{
    ICollection<ReadTrainingDto> ListByStudent(int studentId);
}
