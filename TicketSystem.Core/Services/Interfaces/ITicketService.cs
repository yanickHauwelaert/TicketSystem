using TicketSystem.Core.Entities;

namespace TicketSystem.Core.Services.Interfaces;

public interface ITicketService
{
    Task<ICollection<Ticket>> GetAllTickets();
    Task<Ticket> GetById(Guid id);
    Task<Ticket> AddTicket(Ticket ticket);
    Task<Ticket> UpdateTicket(Ticket ticket);
    Task<Ticket> DeleteTicket(Ticket ticket);
}