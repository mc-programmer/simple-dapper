using Microsoft.EntityFrameworkCore;
using simple_dapper.domain.Models.Note;

namespace simple_dapper.infrastructure.Persistence;

public class ApplicationContext (DbContextOptions<ApplicationContext> options): DbContext(options)
{
    #region Dbsets

    public DbSet<Note> Notes { get; set; }

    #endregion
}