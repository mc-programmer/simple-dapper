namespace simple_dapper.domain.Models.Common;

public class BaseEntity<TKey>
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public TKey Id { get; set; }
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public DateTime CreatedDateOnUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDateOnUtc { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; }
}

public class BaseEntity : BaseEntity<int>;