using simple_dapper.application.Services.Interfaces;
using simple_dapper.domain.Interfaces;
using simple_dapper.domain.Models.Note;

namespace simple_dapper.application.Services.Implementations;

public class NoteService(INoteRepository noteRepository) : INoteService
{
    public bool Create(Note note)
    {
        throw new NotImplementedException();
    }

    public Note? GetById(int id)
    {
        return noteRepository.GetNoteById(id);
    }
}