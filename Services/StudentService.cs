using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using Namespace;

namespace GymAPI.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentMapper _studentMapper;

    public StudentService(
        IStudentRepository studentRepository, 
        IStudentMapper studentMapper
    )
    {
        _studentRepository = studentRepository;
        _studentMapper = studentMapper;
    }

    public ReadStudentDto CreateStudent(CreateStudentDto studentDto)
    {
        var student = _studentMapper.Map(studentDto);

        _studentRepository.Create(student);

        return _studentMapper.Map(student);
    }
}
