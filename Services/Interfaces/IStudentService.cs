using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;

namespace GymAPI.Services.Interfaces;

public interface IStudentService
{
    Task<ReadStudentDto> CreateStudentAsync(CreateStudentDto studentDto);
    Task<ReadStudentDto> GetStudentAsync(int id);
    ICollection<ReadStudentDto> ListStudents();
    Task<ReadStudentDto> UpdateStudentAsync(int id, UpdateStudentDto studentDto);
    Task DeleteStudentAsync(int id);
}
