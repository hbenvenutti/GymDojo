using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;

namespace GymAPI.Services.Interfaces;

public interface IStudentService
{
    Task<IReadStudentDto> CreateStudentAsync(CreateStudentDto studentDto);
    Task<IReadStudentDto> GetStudentAsync(int id);
    ICollection<ReadStudentDtoWithRelations> ListStudents();
    Task<IReadStudentDto> UpdateStudentAsync(int id, UpdateStudentDto studentDto);
    Task DeleteStudentAsync(int id);
}
