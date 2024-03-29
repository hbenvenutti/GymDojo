using GymAPI.Dtos.Request;
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
            var exercises = _exerciseService
                .List();

            return Ok(exercises);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);
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
            var exercise = await _exerciseService
                .GetByIdAsync(id);

            return Ok(exercise);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPost]
    [ProducesResponseType(typeof(IReadExerciseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> CreateExercise(
        [FromBody] CreateExerciseDto createExerciseDto
    )
    {
        try
        {
            var exercise = await _exerciseService
                .CreateAsync(createExerciseDto);

            return CreatedAtAction(
                nameof(GetById), 
                new { id = exercise.Id }, 
                exercise
            );
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(IReadExerciseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> UpdateExercise(
        [FromRoute] int id,
        [FromBody] UpdateExerciseDto updateExerciseDto
    )
    {
        try
        {
            var exercise = await _exerciseService
                .UpdateAsync(id, updateExerciseDto);

            return Ok(exercise);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(IReadExerciseDto), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> DeleteExercise([FromRoute] int id)
    {
        try
        {
            await _exerciseService
                .DeleteByIdAsync(id);

            return NoContent();
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);
        }
    }
}
