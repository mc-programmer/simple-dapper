using simple_dapper.domain.Models.Common;

namespace simple_dapper.domain.Models.Note;

public class Note:BaseEntity
{
    public string? Title { get; set; }
}