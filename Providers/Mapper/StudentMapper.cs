using AutoMapper;
using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Models;
using GymAPI.Providers.Mapper.Interfaces;

namespace GymAPI.Providers.Mapper;

public class StudentMapper : IStudentMapper
{
    private readonly IMapper _mapper;

    public StudentMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    // ---------------------------------------------------------------------- //

    public Student ToStudent(CreateStudentDto dto) => _mapper.Map<Student>(dto);

    public ReadStudentDto ToReadDto(Student student) => 
        _mapper.Map<ReadStudentDto>(student);

    public ICollection<ReadStudentDto> ToReadDto(ICollection<Student> students) => 
        _mapper.Map<ICollection<ReadStudentDto>>(students);
}
