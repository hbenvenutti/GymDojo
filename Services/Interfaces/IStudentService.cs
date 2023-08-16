using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;

namespace GymAPI.Services.Interfaces;

public interface IStudentService
{
    Task<ReadStudentDto> CreateStudent(CreateStudentDto studentDto);
    Task<ReadStudentDto> GetStudent(int id);
    ICollection<ReadStudentDto> ListStudents();
    Task<ReadStudentDto> UpdateStudent(int id, UpdateStudentDto studentDto);
}
