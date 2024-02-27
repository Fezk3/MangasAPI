using MangasAPI.Models.Domain;

namespace MangasAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {

        Task<Category> CreateAsync(Category category);

    }
}
