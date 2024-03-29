using GymAPI.Dtos.Response.interfaces;

namespace GymAPI.Dtos.Response;

public class ReadStudentDtoWithRelations : IReadStudentDto
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

    public required ICollection<ReadTrainingDto> Trainings { get; set; }    

}
