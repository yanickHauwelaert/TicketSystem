using TicketSystem.Core.Entities;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.Core.Services.Interfaces;

namespace TicketSystem.Core.Services;

public class CategoryService : ICategoryService
{
    protected readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<ICollection<Category>> GetALlCategories()
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public Task<Category> GetCategoryById(Guid id)
    {
        var category = _categoryRepository.GetByIdAsync(id);
        return category;
    }

    public Task<Category> AddCategory(Category ticket)
    {
        var addedCategory = _categoryRepository.AddAsync(ticket);
        return addedCategory;
    }

    public Task<Category> UpdateCategory(Category ticket)
    {
        var updatedCategory = _categoryRepository.UpdateAsync(ticket);
        return updatedCategory;
    }

    public Task<Category> DeleteCategory(Category ticket)
    {
        var DeletedCategory = _categoryRepository.DeletAsynct(ticket);
        return DeletedCategory;
    }
}