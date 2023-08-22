using GymDojo.Dtos.Response.interfaces;

namespace GymDojo.Dtos.Response;

public class ReadStudentDto : IReadStudentDto
{
    public int Id { get; init; }

    public required string Name { get; init; }
    public required string Gender { get; init; }

    public uint Age { get; init; }

    public double Weight { get; init; }
    public double Height { get; init; }
    public double ArmCircumference { get; init; }
    public double WaistCircumference { get; init; }
    public double AbdominalCircumference { get; init; }
    public double ChestCircumference { get; init; }
}
