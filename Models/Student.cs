using System.Text.Json.Serialization;

namespace GymAPI.Models;

public class Student
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public required string Gender { get; set; }
    
    public uint Age { get; set; }
    
    public double Weight { get; set; }
    public double Height { get; set; }
    public double ArmCircumference { get; set; }
    public double WaistCircumference { get; set; }
    public double AbdomenCircumference { get; set; }
    public double ChestCircumference { get; set; }

    // [JsonIgnore]
    // public ICollection<Training> Trainings { get; set; }

    // ---------------------------------------------------------------------- //

    // public Student()
    // {
    //     Trainings = new List<Training>();
    // }
}
