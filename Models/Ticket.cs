namespace Person.Models;

public class Ticket
{
    private Ticket() { }

    public Ticket(TicketRequest req)
    {
        Title = req.Title;
        Description = req.Description;
        Priority = req.Priority;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateTicket(TicketRequest req)
    {
        Title = req.Title;
        Description = req.Description;
        Priority = req.Priority;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Close()
    {
        Status = Status.Closed;
        UpdatedAt = DateTime.UtcNow;
    }

    public TicketResponse ToResponse() => new(
        Id, Title, Description, Priority, Status, CreatedAt, UpdatedAt);

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public Priority Priority { get; set; }
    public Status Status { get; set; }
}