namespace Person.Models;

public class Ticket
{
    public Ticket(string title, string description, DateTime createdAt, DateTime updatedAt, Priority priority, Status status)
    {
        Title = title;
        Description = description;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Priority = priority;
        Status = status;
    }
    
    public Guid Id { get; init; } =  Guid.NewGuid();
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Priority Priority { get; set; }
    public Status Status { get; set; }
}