namespace GymDojo.Dtos.Response.interfaces;

public interface IReadStudentDto
{
    int Id { get; init; }

    string Name { get; init; }
    string Gender { get; init; }

    uint Age { get; init; }

    double Weight { get; init; }
    double Height { get; init; }
    double ArmCircumference { get; init; }
    double WaistCircumference { get; init; }
    double AbdominalCircumference { get; init; }
    double ChestCircumference { get; init; }
}
