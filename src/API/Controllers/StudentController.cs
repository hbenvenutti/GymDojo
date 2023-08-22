using GymDojo.API.Handlers;
using GymDojo.Application.Commands.Requests;
using GymDojo.Application.Handlers.Students.interfaces;
using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymDojo.API.Controllers;

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
            var students = _studentService
                .List();

            return Ok(students);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPost]

    public async Task<IActionResult> Create(
        [FromServices] ICreateStudentHandler handler,
        [FromBody] CreateStudentRequest command
    )
    {}

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IReadStudentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {
            var student = await _studentService
                .GetByIdAsync(id);

            return Ok(student);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);
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
            var student = await _studentService
                .CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById), 
                new { id = student.Id }, 
                student
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
            var student = await _studentService
                .UpdateAsync(id, dto);

            return Ok(student);
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler
                .HandleException(exception);
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
            await _studentService
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
