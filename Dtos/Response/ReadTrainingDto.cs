using GymAPI.Models;

namespace GymAPI.Dtos.Response;

public class ReadTrainingDto
{
    public int Id { get; init; }
    public int StudentId { get; init; }
    public required string Name { get; init; }

    public required ReadStudentDto Student { get; init; }
}
