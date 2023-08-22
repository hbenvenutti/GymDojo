namespace GymDojo.Exceptions;

public class ExerciseNotFoundException : NotFoundException
{
    private static readonly string _message = "Exercise not found";
    
    public ExerciseNotFoundException() : base(_message) {}
}
