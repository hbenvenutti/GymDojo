using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Handlers;
using GymAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

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
            var trainings = _trainingService.ListByStudent(id);
            return Ok(trainings);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);            
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
            var training = await _trainingService.GetByIdAsync(trainingId);
            return Ok(training);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);            
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPost]
    [ProducesResponseType(typeof(IReadTrainingDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Create([FromBody] CreateTrainingDto createTrainingDto)
    {
        try
        {
            var training = await _trainingService
                .CreateTrainingAsync(createTrainingDto);

            return CreatedAtAction(
                nameof(GetById), 
                new { trainingId = training.Id }, 
                training
            );
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);            
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPut("{trainingId}")]
    [ProducesResponseType(typeof(IReadTrainingDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Update(
        [FromRoute] int trainingId, 
        [FromBody] UpdateTrainingDto updateTrainingDto
    )
    {
        try
        {
            var training = await _trainingService
                .UpdateTrainingAsync(trainingId, updateTrainingDto);

            return Ok(training);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);            
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
            await _trainingService.DeleteTrainingAsync(trainingId);
            
            return NoContent();
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);            
        }
    }
}
