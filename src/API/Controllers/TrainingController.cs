using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Handlers;
using GymDojo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymDojo.API.Controllers;

[ApiController]
[Route("treinos")]
public class TrainingController : ControllerBase
{
    private readonly ITrainingService _trainingService;

    // ---------------------------------------------------------------------- //

    public TrainingController(ITrainingService trainingService)
    {
        _trainingService = trainingService;
    }

    // ---------------------------------------------------------------------- //

    [HttpGet("/alunos/{id}/treinos")]
    [ProducesResponseType(typeof(ICollection<IReadTrainingDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public IActionResult ListByStudent([FromRoute] int id)
    {
        try
        {
            var trainings = _trainingService
                .ListByStudent(id);

            return Ok(trainings);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);            
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpGet("{trainingId}")]
    [ProducesResponseType(typeof(IReadTrainingDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> GetById([FromRoute] int trainingId)
    {
        try
        {
            var training = await _trainingService
                .GetByIdAsync(trainingId);

            return Ok(training);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);            
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPost]
    [ProducesResponseType(typeof(IReadTrainingDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Create([FromBody] CreateTrainingDto createDto)
    {
        try
        {
            var training = await _trainingService
                .CreateAsync(createDto);

            return CreatedAtAction(
                nameof(GetById), 
                new { trainingId = training.Id }, 
                training
            );
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);            
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPut("{trainingId}")]
    [ProducesResponseType(typeof(IReadTrainingDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Update(
        [FromRoute] int trainingId, 
        [FromBody] UpdateTrainingDto updateDto
    )
    {
        try
        {
            var training = await _trainingService
                .UpdateAsync(trainingId, updateDto);

            return Ok(training);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);            
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpDelete("{trainingId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Delete([FromRoute] int trainingId)
    {
        try
        {
            await _trainingService
                .DeleteByIdAsync(trainingId);
            
            return NoContent();
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);            
        }
    }
}
