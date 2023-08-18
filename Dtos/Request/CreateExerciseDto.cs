namespace GymAPI.Dtos.Request;

public class CreateExerciseDto
{
    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public required string Photo { get; set; }
}
