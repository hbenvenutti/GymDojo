using GymAPI.Dtos.Response.interfaces;

namespace GymAPI.Dtos.Response;

public class ReadTrainingDtoWithRelations : IReadTrainingDto
{
    public int Id { get; init; }
    public int StudentId { get; init; }
    public required string Name { get; init; }

    public required ReadStudentDto Student { get; set; }
}
