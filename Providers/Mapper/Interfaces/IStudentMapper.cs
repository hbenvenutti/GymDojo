using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface IStudentMapper
{
    Student ToStudent(CreateStudentDto dto);
    Student ToStudent(UpdateStudentDto dto);
    Student UpdateStudent(UpdateStudentDto dto, Student student);

    CreateStudentDto ToCreateDto(UpdateStudentDto dto);

    ReadStudentDto ToReadDto(Student student);

    ICollection<ReadStudentDto> ToReadDto(ICollection<Student> students);
}
