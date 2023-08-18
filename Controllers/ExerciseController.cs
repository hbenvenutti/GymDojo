using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Handlers;
using GymAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[ApiController]
[Route("exercicios")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    // ---------------------------------------------------------------------- //

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    // ---------------------------------------------------------------------- //

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<IReadExerciseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    
    public IActionResult ListExercises()
    {
        try
        {
            var exercises = _exerciseService.ListExercises();

            return Ok(exercises);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }
}

