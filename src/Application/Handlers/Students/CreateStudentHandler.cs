using GymDojo.Application.Commands.Requests;
using GymDojo.Application.Commands.Responses;
using GymDojo.Application.Handlers.Students.interfaces;
using GymDojo.Domain.Repositories;
using GymDojo.Providers.Mapper.Interfaces;

namespace GymDojo.Application.Handlers.Students;

public class CreateStudentHandler : ICreateStudentHandler
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapperProvider _mapper;

    public CreateStudentHandler(
        IStudentRepository studentRepository,
        IMapperProvider mapper
    )
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<CreateStudentResponse> Handle(CreateStudentRequest request)
    {
        var student = _mapper
            .StudentMapper
            .ToModel(request);

        student = await _studentRepository
            .CreateAsync(student);

        var studentDto = _mapper
            .StudentMapper
            .ToReadDto(student);

        return studentDto;
    }
}
