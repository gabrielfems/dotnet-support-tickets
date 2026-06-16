namespace Person.Models;

public record TicketRequest(
    string Title, 
    string Description, 
    Priority Priority);