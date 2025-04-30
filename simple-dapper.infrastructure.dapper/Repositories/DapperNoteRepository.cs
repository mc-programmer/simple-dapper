using Dapper;
using simple_dapper.domain.Interfaces;
using simple_dapper.domain.Models.Note;
using System.Data.SqlClient;

namespace simple_dapper.infrastructure.dapper.Repositories;

public class DapperNoteRepository : INoteRepository
{
    private readonly string connectionString = "Server=.;Database=simple_dapper_db;Trusted_Connection=true;TrustServerCertificate=True;Integrated Security=True;";

    public IEnumerable<Note> GetAll()
    {
        string query = "SELECT * FROM Notes;";

        var connection = new SqlConnection(connectionString);

        var result = connection.Query<Note>(query);

        return result;
    }

    public Note? GetNoteById(int id)
    {
        string query = "SELECT * FROM Notes WHERE Id = @Id;";

        var connection = new SqlConnection(connectionString);

        var result = connection.QuerySingleOrDefault<Note>(query, new { Id = id });

        return result;
    }

    public void Insert(Note note)
    {
        string query = "INSERT INTO Notes (Title,CreatedDateOnUtc , UpdatedDateOnUtc) VALUES (@Title , @CreatedDate , @UpdatedDate)";

        var connection = new SqlConnection(connectionString);

        var result = connection.Execute(query, new { Title = note.Title, CreatedDate = note.CreatedDateOnUtc, UpdatedDate = note.UpdatedDateOnUtc });
    }

    public void Update(Note note)
    {
        string query = "UPDATE Notes SET Title = @Title , UpdatedDateOnUtc = @UpdatedDate WHERE Id = @Id";

        var connection = new SqlConnection(connectionString);

        connection.Execute(query, new { Id = note.Id, Title = note.Title, UpdatedDate = note.UpdatedDateOnUtc });
    }

    public void Delete(int id)
    {
        string query = "UPDATE Notes SET IsDeleted = 1 WHERE Id = @Id";

        var connection = new SqlConnection(connectionString);

        connection.Execute(query, new { Id = id });
    }
}