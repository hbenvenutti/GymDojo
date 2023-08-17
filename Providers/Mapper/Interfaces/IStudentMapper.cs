using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface IStudentMapper
{
    Student ToStudent(CreateStudentDto dto);
    Student ToStudent(UpdateStudentDto dto);
    Student UpdateStudent(UpdateStudentDto dto, Student student);

    CreateStudentDto ToCreateDto(UpdateStudentDto dto);

    IReadStudentDto ToReadDto(Student student);

    ICollection<ReadStudentDto> ToReadDtoCollection(ICollection<Student> students);

    IReadStudentDto ToReadDtoWithRelations(Student student);

    ICollection<ReadStudentDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Student> students
    );
}
