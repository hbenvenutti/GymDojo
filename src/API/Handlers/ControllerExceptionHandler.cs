using GymDojo.Dtos.Response;
using GymDojo.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GymDojo.API.Handlers;

public static class ControllerExceptionHandler
{
    public static IActionResult HandleException(Exception exception)
    {
        ErrorDto errorDto = new(exception.Message);

        if (exception is NotFoundException) 
            return new NotFoundObjectResult(errorDto);

        if (exception is BadRequestException) 
            return new BadRequestObjectResult(errorDto);

        return new ObjectResult(errorDto) { StatusCode = 500 };
    }
}
