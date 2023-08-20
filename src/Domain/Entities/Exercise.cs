namespace GymDojo.Domain.Entities;

public class Exercise
{
    public int Id { get; set; }

    public required string Name { get; set; }
    
    public string? Description { get; set; }
    
    public required string Photo { get; set; }
}
