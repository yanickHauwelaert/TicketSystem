using TicketSystem.Core.Entities;

namespace TicketSystem.Core.Repositories.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<ApplicationUser>> GetAll();
    Task<ApplicationUser> GetByIdAsync(Guid id);
    
    Task<ApplicationUser> AddAsync(ApplicationUser user);
    Task<ApplicationUser> UpdateAsync(ApplicationUser user);
}