using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Models;

namespace GymDojo.Services.Interfaces;

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
