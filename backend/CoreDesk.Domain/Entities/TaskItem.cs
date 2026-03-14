namespace CoreDesk.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Status { get; set; } = "Todo";

    public string Priority { get; set; } = "Normal";

    public DateTime? DueDate { get; set; }

    public Guid ProjectId { get; set; }
    public Guid CompanyId { get; set; }

    public Guid CreatedByUserId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}