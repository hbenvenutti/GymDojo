using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Models;

namespace GymDojo.Providers.Mapper.Interfaces;

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
