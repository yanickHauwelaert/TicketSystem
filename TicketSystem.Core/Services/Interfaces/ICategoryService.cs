using TicketSystem.Core.Entities;

namespace TicketSystem.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<ICollection<Category>> GetALlCategories();
    Task<Category> GetCategoryById(Guid id);
    Task<Category> AddCategory(Category ticket);
    Task<Category> UpdateCategory(Category ticket);
    Task<Category> DeleteCategory(Category ticket);
}