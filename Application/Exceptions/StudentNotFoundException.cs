namespace GymAPI.Exceptions;

public class StudentNotFoundException : NotFoundException
{
    private static readonly string _message = "Student not found";

    public StudentNotFoundException() : base(_message) {}
}
