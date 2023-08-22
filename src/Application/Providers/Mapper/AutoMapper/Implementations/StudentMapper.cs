using AutoMapper;
using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Models;
using GymDojo.Providers.Mapper.Interfaces;

namespace GymDojo.Providers.Mapper.AutoMapper.Implementations;

public class StudentMapper : IStudentMapper
{
    private readonly IMapper _mapper;

    // ---------------------------------------------------------------------- //

    public StudentMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    // ---------------------------------------------------------------------- //

    public Student ToModel(CreateStudentDto dto) => _mapper.Map<Student>(dto);

    public Student ToModel(UpdateStudentDto dto) => _mapper.Map<Student>(dto);

    // ---------------------------------------------------------------------- //

    public Student ToExistentModel(UpdateStudentDto dto, Student student) =>
        _mapper.Map(dto, student);

    public CreateStudentDto ToCreateDto(UpdateStudentDto dto) =>
        _mapper.Map<CreateStudentDto>(dto);

    // ---------------------------------------------------------------------- //

    public IReadStudentDto ToReadDto(Student student) => 
        _mapper.Map<ReadStudentDto>(student);

    public ICollection<ReadStudentDto> ToReadDtoCollection(
        ICollection<Student> students
    ) => _mapper.Map<ICollection<ReadStudentDto>>(students);

    // ---------------------------------------------------------------------- //

    public IReadStudentDto ToReadDtoWithRelations(Student student) =>
        _mapper.Map<ReadStudentDtoWithRelations>(student);

    public ICollection<ReadStudentDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Student> students
    ) => _mapper.Map<ICollection<ReadStudentDtoWithRelations>>(students);
}
