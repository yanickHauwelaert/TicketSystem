using System.Reflection.Metadata.Ecma335;
using TicketSystem.Core.Entities;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.Core.Services.Interfaces;

namespace TicketSystem.Core.Services;

public class TicketService : ITicketService
{
    protected readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<ICollection<Ticket>> GetAllTickets()
    {
        return await _ticketRepository.GetAll();
    }

    public  Task<Ticket> GetById(Guid id)
    {
        var ticket =  _ticketRepository.GetByIdAsync(id);
        return ticket;
    }

    public  Task<Ticket> AddTicket(Ticket ticket)
    {
        var addTicket =  _ticketRepository.AddAsync(ticket);
        return addTicket;
    }

    public Task<Ticket> UpdateTicket(Ticket ticket)
    {
        var updatedTicket = _ticketRepository.UpdateAsync(ticket);
        return updatedTicket;
    }

    public Task<Ticket> DeleteTicket(Ticket ticket)
    {
        var deletedTicket = _ticketRepository.DeletAsynct(ticket);
        return deletedTicket;
    }

}