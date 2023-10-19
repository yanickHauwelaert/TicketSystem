using TicketSystem.Core.Entities;

namespace TicketSystem.Core.Services.Interfaces;

public interface ICategoryService
{
    Task<ICollection<Category>> GetALlCategories();
    Task<Category> GetCategoryById();
    Task<Category> AddCategory();
    Task<Category> UpdateCategory();
    Task<Category> DeleteCategory();
}