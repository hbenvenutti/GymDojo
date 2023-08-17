namespace GymAPI.Exceptions;

public class InexistentStudentException : BadRequestException
{
    private static readonly string _message = "invalid student id";

    public InexistentStudentException() : base(_message) {}
}
