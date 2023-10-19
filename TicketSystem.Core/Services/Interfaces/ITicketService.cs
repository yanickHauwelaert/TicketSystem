using TicketSystem.Core.Entities;

namespace TicketSystem.Core.Services.Interfaces;

public interface ITicketService
{
    Task<ICollection<Ticket>> GetAllTickets();
    Task<Ticket> GetById();
    Task<Ticket> AddTicket();
    Task<Ticket> UpdateTicket();
    Task<Ticket> DeleteTicket();
}