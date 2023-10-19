using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Entities;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.Infrastructure.Data;

namespace TicketSystem.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
{
    protected readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbContext.Set<T>().SingleOrDefaultAsync(t => t.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeletAsynct(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}