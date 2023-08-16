using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;

namespace Namespace;

public interface IStudentService
{
    ReadStudentDto CreateStudent(CreateStudentDto studentDto);
}
