using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Handlers;
using GymAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers;

[ApiController]
[Route("alunos")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    // ---------------------------------------------------------------------- //
    
    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // ---------------------------------------------------------------------- //

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<IReadStudentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public IActionResult List()
    {
        try
        {
            var students = _studentService.ListStudents();

            return Ok(students);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IReadStudentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var student = await _studentService.GetStudentAsync(id);

            return Ok(student);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPost]
    [ProducesResponseType(typeof(IReadStudentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
    {
        try
        {
            var student = await _studentService.CreateStudentAsync(dto);

            return CreatedAtAction(
                nameof(GetById), 
                new { id = student.Id }, 
                student
            );
        }
        
        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(IReadStudentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] UpdateStudentDto dto
    )
    {
        try
        {
            var student = await _studentService.UpdateStudentAsync(id, dto);

            return Ok(student);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _studentService.DeleteStudentAsync(id);

            return NoContent();
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }
}
