using MangasAPI.Models.Domain;

namespace MangasAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {

        Task<Category> CreateAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task<Category> DeleteAsync(Guid id);

        Task<Category> GetByIdAsync(Guid id);

        Task<IEnumerable<Category>> GetAllAsync();

    }
}
