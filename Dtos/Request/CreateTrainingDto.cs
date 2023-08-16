namespace GymAPI.Dtos.Request;

public class CreateTrainingDto
{
    public int StudentId { get; init; }
    public required string Name { get; init; }
}
