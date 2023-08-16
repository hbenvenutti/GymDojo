using System.Text.Json.Serialization;

namespace GymAPI.Models;

public class Training
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public required string Name { get; set; }

    [JsonIgnore]
    public required Student Student { get; set; }
    
    // public ICollection<ExerciseDetail> ExerciseDetails { get; set; } 
}
