namespace CoreDesk.Domain.Entities;

public class Note
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public Guid ProjectId { get; set; }
    public Guid CompanyId { get; set; }

    public Guid CreatedByUserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}