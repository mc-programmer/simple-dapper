using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using simple_dapper.application.Services.Interfaces;

namespace simple_dapper.api.Controllers.V1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class NoteController(INoteService noteService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id <= 0) return BadRequest("please enter a valid id");

        var result = noteService.GetById(id);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(object note) => Created();

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) => Ok();
}