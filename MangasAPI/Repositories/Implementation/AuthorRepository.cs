using MangasAPI.Data;
using MangasAPI.Models.Domain;
using MangasAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace MangasAPI.Repositories.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {

        private readonly ApplicationDbContext dbContext;

        public AuthorRepository(ApplicationDbContext dbContext) 
        {
        
            this.dbContext = dbContext;

        }

        public async Task<Author> CreateAsync(Author author)
        {
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();

            return author;
        }

        public async Task<Boolean> DeleteAsync(Guid id)
        {
            var authorToDelete = await dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if ( authorToDelete == null)
            {

                return false;

            }

            dbContext.Authors.Remove(authorToDelete);
            await dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var authors = await dbContext.Authors.ToListAsync();

            if (authors.Count == 0)
            {
                return null;
            }

            return authors;

        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            var authorLookUp = await dbContext.Authors.FindAsync(id);

            if (authorLookUp == null)
            {
                return null;
            }

            return authorLookUp;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            
            var authorToUpdate = await dbContext.Authors.FindAsync(author.Id);

            if (authorToUpdate == null)
            {
                return null;
            }

            authorToUpdate.Name = author.Name;
            await dbContext.SaveChangesAsync();

            return authorToUpdate;


        }
    }
}
