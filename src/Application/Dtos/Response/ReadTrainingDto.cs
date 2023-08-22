using GymDojo.Dtos.Response.interfaces;

namespace GymDojo.Dtos.Response;

public class ReadTrainingDto : IReadTrainingDto
{
    public int Id { get; init; }
    public int StudentId { get; init; }
    public required string Name { get; init; }
}
