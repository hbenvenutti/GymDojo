using GymAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Handlers;

public static class ControllerExceptionHandler
{
    public static IActionResult HandleException(Exception exception)
    {
        if (exception is NotFoundException) 
            return new NotFoundObjectResult(exception.Message);

        if (exception is BadRequestException) 
            return new BadRequestObjectResult(exception.Message);

        return new ObjectResult(exception.Message) { StatusCode = 500 };
    }
}
