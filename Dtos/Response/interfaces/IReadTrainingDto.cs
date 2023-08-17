namespace GymAPI.Dtos.Response.interfaces;

public interface IReadTrainingDto
{
    int Id { get; init; }
    int StudentId { get; init; }
    string Name { get; init; }
}
