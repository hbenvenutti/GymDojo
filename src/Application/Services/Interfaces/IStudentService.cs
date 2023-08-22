using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Models;

namespace GymDojo.Services.Interfaces;

public interface IStudentService :
    IModelService<
        Student, 
        CreateStudentDto, 
        UpdateStudentDto, 
        IReadStudentDto, 
        ReadStudentDtoWithRelations>
{}
