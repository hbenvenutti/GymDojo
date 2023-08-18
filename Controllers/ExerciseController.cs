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

    // ---------------------------------------------------------------------- //

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IReadExerciseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var exercise = await _exerciseService.GetExerciseAsync(id);

            return Ok(exercise);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }
}
