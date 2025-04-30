using simple_dapper.domain.Models.Note;

namespace simple_dapper.application.Services.Interfaces;

public interface INoteService
{
    void Create(Note note);
    void Update(Note note);
    IEnumerable<Note> GetAll();
    void Delete(int id);
    Note? GetById(int id);
}