namespace GymDojo.Dtos.Response;

public class ErrorDto
{
    public string Message { get; init; }

    public ErrorDto(string message)
    {
        Message = message;
    }
}
