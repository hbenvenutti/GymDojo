namespace GymAPI.Exceptions;

public class TrainingNotFoundException : NotFoundException
{
    private static readonly string _message = "training not found";

    public TrainingNotFoundException() : base(_message) {}
}
