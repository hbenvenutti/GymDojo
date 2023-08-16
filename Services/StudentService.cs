using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Exceptions;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Providers.Mapper.Interfaces;
using GymAPI.Services.Interfaces;

namespace GymAPI.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentMapper _studentMapper;

    // ---------------------------------------------------------------------- //

    public StudentService(
        IStudentRepository studentRepository, 
        IStudentMapper studentMapper
    )
    {
        _studentRepository = studentRepository;
        _studentMapper = studentMapper;
    }

    // ---------------------------------------------------------------------- //

    public async Task<ReadStudentDto> CreateStudent(CreateStudentDto studentDto)
    {
        var student = _studentMapper.ToStudent(studentDto);

        student = await _studentRepository.Create(student);

        return _studentMapper.ToReadDto(student);
    }

    public async Task<ReadStudentDto> GetStudent(int id)
    {
        var student = await _studentRepository.FindById(id)
            ?? throw new StudentNotFoundException();
        
        return _studentMapper.ToReadDto(student);
    }
}
