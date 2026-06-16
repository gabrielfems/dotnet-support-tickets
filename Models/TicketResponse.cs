namespace Person.Models;

public record TicketResponse(
    Guid Id,
    string Title,
    string Description,
    Priority Priority,
    Status Status,
    DateTime CreatedAt,
    DateTime UpdatedAt);