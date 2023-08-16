using GymAPI.Dtos.Request;
using GymAPI.Handlers;
using Microsoft.AspNetCore.Mvc;
using Namespace;

namespace GymAPI.Controllers;

[ApiController]
[Route("alunos")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // ---------------------------------------------------------------------- //

    [HttpGet]
    public IActionResult List()
    {
        try
        {
            return Ok();
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            return Ok();
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpPost]
    public IActionResult Create([FromBody] CreateStudentDto dto)
    {
        try
        {
            var student = _studentService.CreateStudent(dto);

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
    public IActionResult Update([FromRoute] int id)
    {
        try
        {
            return Ok();
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }

    // ---------------------------------------------------------------------- //

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            return NoContent();
        }

        catch (Exception exception)
        {
            return ControllerExceptionHandler.HandleException(exception);
        }
    }
}
