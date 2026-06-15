using Person.Models;

namespace Person.Routes;

public static class TicketRoute
{
    public static void TicketRoutes(this WebApplication app)
    {
        app.MapGet("ticket", () => new Ticket("Login page returning 500",
            "Users are unable to log in. The server returns a 500 error after submitting credentials",
            DateTime.UtcNow
            ,DateTime.UtcNow,
            Priority.High,
            Status.Closed));
    }
}