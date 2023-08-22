namespace GymDojo.Dtos.Response.interfaces;

public interface IReadExerciseDto
{
    int Id { get; set; }

    string Name { get; set; }
    
    string? Description { get; set; }
    
    string Photo { get; set; }
}
