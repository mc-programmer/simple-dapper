using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using simple_dapper.application.Services.Interfaces;
using simple_dapper.domain.Models.Note;

namespace simple_dapper.api.Controllers.V1;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
public class NoteController(INoteService noteService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(noteService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id <= 0) return BadRequest("please enter a valid id");

        var result = noteService.GetById(id);

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Note note)
    {
        if (!ModelState.IsValid) return BadRequest("please enter valid data");

        noteService.Create(note);

        return Created();
    }

    [HttpPut]
    public IActionResult Put([FromBody] Note note)
    {
        if (!ModelState.IsValid) return BadRequest("please enter valid data");

        noteService.Update(note);

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (id <= 0) return BadRequest("please enter a valid id");

        noteService.Delete(id);

        return Ok();
    }
}