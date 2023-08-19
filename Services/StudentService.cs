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
    private readonly IMapperProvider _mapper;

    // ---------------------------------------------------------------------- //

    public StudentService(
        IStudentRepository studentRepository, 
        IMapperProvider mapper
    )
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadStudentDto> CreateStudentAsync(
        CreateStudentDto createDto
    )
    {
        var student = _mapper
            .StudentMapper
            .ToModel(createDto);

        student = await _studentRepository
            .CreateAsync(student);

        var studentDto = _mapper
            .StudentMapper
            .ToReadDto(student);

        return studentDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadStudentDto> GetStudentAsync(int studentId)
    {
        var student = await _studentRepository
            .FindByIdAsync(studentId)
            ?? throw new StudentNotFoundException();

        var dto = _mapper
            .StudentMapper
            .ToReadDtoWithRelations(student);

        return dto;
    }

    // ---------------------------------------------------------------------- //

    public ICollection<ReadStudentDtoWithRelations> ListStudents()
    {
        var students = _studentRepository
            .List();

        var dto = _mapper
            .StudentMapper
            .ToReadDtoWithRelationsCollection(students);

        return dto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadStudentDto> UpdateStudentAsync(
        int studentId, 
        UpdateStudentDto updateDto
    )
    {
        var student = await _studentRepository
            .FindByIdAsync(studentId);

        if (student is null) 
            return await CreateStudentAsync(
                _mapper
                    .StudentMapper
                    .ToCreateDto(updateDto)
            );

        student = _mapper.StudentMapper.ToExistentModel(updateDto, student);

        await _studentRepository.UpdateAsync(student);

        var studentDto = _mapper.StudentMapper.ToReadDtoWithRelations(student);

        return studentDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteStudentAsync(int studentId)
    {
        var student = await _studentRepository
            .FindByIdAsync(studentId)
            ?? throw new StudentNotFoundException();

        await _studentRepository
            .DeleteAsync(student);

        return;
    }
}
