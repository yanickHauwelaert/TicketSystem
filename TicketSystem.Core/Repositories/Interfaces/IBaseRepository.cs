using TicketSystem.Core.Entities;

namespace TicketSystem.Core.Repositories.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<ICollection<T>> GetAll();
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeletAsynct(T entity);
}