using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Services.Interfaces;

public interface IStudentService :
    IModelService<
        Student, 
        CreateStudentDto, 
        UpdateStudentDto, 
        IReadStudentDto, 
        ReadStudentDtoWithRelations>
{}
