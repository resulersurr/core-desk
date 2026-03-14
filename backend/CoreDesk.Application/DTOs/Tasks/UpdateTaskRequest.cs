namespace CoreDesk.Application.DTOs.Tasks;

public class UpdateTaskRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = "Todo";
    public string Priority { get; set; } = "Normal";
    public DateTime? DueDate { get; set; }
}