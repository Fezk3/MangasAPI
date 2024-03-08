using MangasAPI.Models.Domain;

namespace MangasAPI.Repositories.Interface
{
    public interface IAuthorRepository
    {

        public Task<Author> CreateAsync(Author author);

        public Task<Author> UpdateAsync(Author author);

        public Task<Boolean> DeleteAsync(Guid id);

        public Task<Author?> GetByIdAsync(Guid id);

        public Task<IEnumerable<Author>> GetAllAsync();

    }
}
