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

    public async Task<ReadStudentDto> CreateStudentAsync(CreateStudentDto dto)
    {
        var student = _studentMapper.ToStudent(dto);

        student = await _studentRepository.Create(student);

        return _studentMapper.ToReadDto(student);
    }

    // ---------------------------------------------------------------------- //

    public async Task<ReadStudentDto> GetStudentAsync(int id)
    {
        var student = await _studentRepository.FindById(id)
            ?? throw new StudentNotFoundException();
        
        return _studentMapper.ToReadDto(student);
    }

    // ---------------------------------------------------------------------- //

    public ICollection<ReadStudentDto> ListStudents()
    {
        var students = _studentRepository.List();

        return _studentMapper.ToReadDto(students);
    }

    // ---------------------------------------------------------------------- //

    public async Task<ReadStudentDto> UpdateStudentAsync(int id, UpdateStudentDto dto)
    {
        var student = await _studentRepository.FindById(id);

        if (student is null) 
            return await CreateStudentAsync(_studentMapper.ToCreateDto(dto));

        student = _studentMapper.UpdateStudent(dto, student);

        await _studentRepository.Update(student);

        return _studentMapper.ToReadDto(student);
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteStudentAsync(int id)
    {
        var student = await _studentRepository.FindById(id)
            ?? throw new StudentNotFoundException();

        await _studentRepository.Delete(student);
    }
}
