using Person.Models;
using Person.Services;

namespace Person.Routes;

public static class TicketRoute
{
    public static void TicketRoutes(this WebApplication app)
    {
        var route = app.MapGroup("ticket");

        route.MapPost("",
            async (TicketRequest req, TicketService service) =>
            {
                var (response, error) = await service.CreateAsync(req);

                if (error is not null)
                    return Results.BadRequest(error);

                return Results.Created($"/ticket/{response!.Id}", response);
            });

        route.MapGet("",
            async (TicketService service) =>
            {
                var tickets = await service.GetAllAsync();
                return Results.Ok(tickets);
            });
        
        route.MapGet("{id:guid}",
            async (Guid id, TicketService service) =>
            {
                var ticket = await service.GetByIdAsync(id);

                if (ticket is null)
                    return Results.NotFound();

                return Results.Ok(ticket);
            });

        route.MapPut("{id:guid}",
            async (Guid id, TicketRequest req, TicketService service) =>
            {
                var (response, error) = await service.UpdateAsync(id, req);

                if (error is not null)
                    return Results.BadRequest(error);

                if (response is null)
                    return Results.NotFound();

                return Results.Ok(response);
            });

        route.MapDelete("{id:guid}",
            async (Guid id, TicketService service) =>
            {
                var result = await service.CloseAsync(id);

                if (result is null)
                    return Results.NotFound();

                return Results.NoContent();
            });
    }
}