using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
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

    public async Task<IReadStudentDto> CreateStudentAsync(CreateStudentDto dto)
    {
        var student = _studentMapper.ToStudent(dto);

        student = await _studentRepository.Create(student);

        var studentDto = _studentMapper.ToReadDto(student);

        return studentDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadStudentDto> GetStudentAsync(int id)
    {
        var student = await _studentRepository.FindById(id)
            ?? throw new StudentNotFoundException();

        var dto = _studentMapper.ToReadDtoWithRelations(student);

        return dto;
    }

    // ---------------------------------------------------------------------- //

    public ICollection<ReadStudentDtoWithRelations> ListStudents()
    {
        var students = _studentRepository.List();

        var dto = _studentMapper.ToReadDtoWithRelationsCollection(students);

        return dto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadStudentDto> UpdateStudentAsync(int id, UpdateStudentDto dto)
    {
        var student = await _studentRepository.FindById(id);

        if (student is null) 
            return await CreateStudentAsync(_studentMapper.ToCreateDto(dto));

        student = _studentMapper.UpdateStudent(dto, student);

        await _studentRepository.Update(student);

        var studentDto = _studentMapper.ToReadDtoWithRelations(student);

        return studentDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteStudentAsync(int id)
    {
        var student = await _studentRepository.FindById(id)
            ?? throw new StudentNotFoundException();

        await _studentRepository.Delete(student);

        return;
    }
}
