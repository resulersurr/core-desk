namespace CoreDesk.Domain.Entities;

public class Project
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid CreatedByUserId { get; set; }

    public Guid CompanyId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}