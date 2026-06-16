using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Models;

namespace Person.Services;

public class TicketService
{
    private readonly TicketContext _context;

    public TicketService(TicketContext context)
    {
        _context = context;
    }

    public async Task<(TicketResponse? response, string? error)> CreateAsync(TicketRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Title))
            return (null, "Title é obrigatório.");

        if (string.IsNullOrWhiteSpace(req.Description))
            return (null, "Description é obrigatório.");

        var ticket = new Ticket(req);
        await _context.AddAsync(ticket);
        await _context.SaveChangesAsync();

        return (ticket.ToResponse(), null);
    }

    public async Task<List<TicketResponse>> GetAllAsync()
        => await _context.Tickets
            .Where(t => t.Status != Status.Closed)
            .Select(t => t.ToResponse())
            .ToListAsync();

    public async Task<(TicketResponse? response, string? error)> UpdateAsync(Guid id, TicketRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Title))
            return (null, "Title é obrigatório.");

        if (string.IsNullOrWhiteSpace(req.Description))
            return (null, "Description é obrigatório.");

        var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);

        if (ticket is null)
            return (null, null);

        ticket.UpdateTicket(req);
        await _context.SaveChangesAsync();

        return (ticket.ToResponse(), null);
    }

    public async Task<bool?> CloseAsync(Guid id)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);

        if (ticket is null)
            return null;

        ticket.Close();
        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<TicketResponse?> GetByIdAsync(Guid id)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        return ticket?.ToResponse();
    }
}