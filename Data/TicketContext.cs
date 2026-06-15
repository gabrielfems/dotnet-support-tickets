using Microsoft.EntityFrameworkCore;
using Person.Models;

namespace Person.Data;

public class TicketContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tickets.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}