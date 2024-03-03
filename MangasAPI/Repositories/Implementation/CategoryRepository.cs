using MangasAPI.Data;
using MangasAPI.Models.Domain;
using MangasAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace MangasAPI.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext dbcontext;


        public CategoryRepository(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Category> CreateAsync(Category category)
        {

            await dbcontext.Categories.AddAsync(category);
            await dbcontext.SaveChangesAsync();

            return category;

        }

        public async Task<Category> DeleteAsync(Guid id)
        {

            var category = await dbcontext.Categories.FindAsync(id);

            if (category == null)
            {
                return null;
            }

            dbcontext.Categories.Remove(category);
            await dbcontext.SaveChangesAsync();

            return null;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await dbcontext.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var category = await dbcontext.Categories.FindAsync(id);

            if (category == null)
            {
                return null;
            }

            return category;

        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var categoryToUpdate = await dbcontext.Categories.FindAsync(category.Id);

            if (categoryToUpdate == null)
            {
                return null;
            }

            categoryToUpdate.Name = category.Name;
            if (category.MangaPosts != null)
            {
                categoryToUpdate.MangaPosts = category.MangaPosts;
            }

            await dbcontext.SaveChangesAsync();

            return categoryToUpdate;

        }
    }
}
