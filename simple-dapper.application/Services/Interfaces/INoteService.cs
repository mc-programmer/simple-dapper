using simple_dapper.domain.Models.Note;

namespace simple_dapper.application.Services.Interfaces;

public interface INoteService
{
    bool Create(Note note);
    Note? GetById(int id);
}