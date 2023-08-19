using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface IStudentMapper : 
    IModelMapper<
        Student, 
        CreateStudentDto, 
        UpdateStudentDto, 
        IReadStudentDto, 
        ReadStudentDto
    >
{
    IReadStudentDto ToReadDtoWithRelations(Student student);

    ICollection<ReadStudentDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Student> students
    );
}
