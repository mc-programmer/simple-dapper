using simple_dapper.application.Services.Interfaces;
using simple_dapper.domain.Interfaces;
using simple_dapper.domain.Models.Note;

namespace simple_dapper.application.Services.Implementations;

public class NoteService(INoteRepository noteRepository) : INoteService
{
    public IEnumerable<Note> GetAll()
    {
        return noteRepository.GetAll();
    }

    public Note? GetById(int id)
    {
        return noteRepository.GetNoteById(id);
    }

    public void Create(Note note)
    {
        noteRepository.Insert(note);
    }

    public void Update(Note note)
    {
        noteRepository.Update(note);
    }

    public void Delete(int id)
    {
        noteRepository.Delete(id);
    }
}