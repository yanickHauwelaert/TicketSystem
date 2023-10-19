using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Entities;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.Infrastructure.Data;

namespace TicketSystem.Infrastructure.Repositories;

public class AccountRepository: IAccountRepository
{
    protected readonly ApplicationDbContext _dbContext;

    public AccountRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<ApplicationUser>> GetAll()
    {
        var users = await _dbContext.Users.ToListAsync();
        return users;
    }

    public async Task<ApplicationUser> GetByIdAsync(Guid id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<ApplicationUser> AddAsync(ApplicationUser user)
    {
        _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<ApplicationUser> DeleteAysnc(ApplicationUser user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }
}