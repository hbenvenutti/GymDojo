using GymAPI.Dtos.Response.interfaces;

namespace GymAPI.Dtos.Response;

public class ReadExerciseDto : IReadExerciseDto
{
    public int Id { get; set; }

    public required string Name { get; set; }
    
    public required string? Description { get; set; }
    
    public required string Photo { get; set; }
}
