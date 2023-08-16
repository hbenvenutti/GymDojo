using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface IStudentMapper
{
    Student ToStudent(CreateStudentDto dto);

    ReadStudentDto ToReadDto(Student student);

    ICollection<ReadStudentDto> ToReadDto(ICollection<Student> students);
}
