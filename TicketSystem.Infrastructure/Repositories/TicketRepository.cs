using TicketSystem.Core.Entities;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.Infrastructure.Data;

namespace TicketSystem.Infrastructure.Repositories;

public class TicketRepository: BaseRepository<Ticket>,ITicketRepository
{
    public TicketRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}