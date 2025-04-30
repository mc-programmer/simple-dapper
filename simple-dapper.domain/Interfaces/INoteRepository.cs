using simple_dapper.domain.Models.Note;

namespace simple_dapper.domain.Interfaces;

public interface INoteRepository
{
    IEnumerable<Note> GetAll();
    Note? GetNoteById(int id);
    void Insert(Note note);
    void Update(Note note);
    void Delete(int id);
}