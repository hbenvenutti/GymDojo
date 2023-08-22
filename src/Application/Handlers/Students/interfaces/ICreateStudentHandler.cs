using GymDojo.Application.Commands.Requests;
using GymDojo.Application.Commands.Responses;

namespace GymDojo.Application.Handlers.Students.interfaces;

public interface ICreateStudentHandler
{
    Task<CreateStudentResponse> Handle(CreateStudentRequest request);
}
