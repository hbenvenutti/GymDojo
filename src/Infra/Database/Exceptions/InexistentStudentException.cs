using GymDojo.Application.Exceptions;

namespace GymDojo.Infra.Exceptions;

public class InvalidForeignKeyException : BadRequestException
{
    private static readonly string _message = "Invalid Foreign Key";

    public InvalidForeignKeyException() : base(_message) {}
}
