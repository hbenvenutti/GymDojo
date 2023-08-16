namespace GymAPI.Dtos.Request;

public class UpdateStudentDto
{
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
