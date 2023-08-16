namespace GymAPI.Dtos.Request;

public class UpdateTrainingDto
{
    public int StudentId { get; init; }
    public required string Name { get; init; }
}
