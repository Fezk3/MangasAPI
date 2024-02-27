using MangasAPI.Data;
using MangasAPI.Models.Domain;
using MangasAPI.Repositories.Interface;
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

        public DbContext Dbcontext { get; }

        public async Task<Category> CreateAsync(Category category)
        {

            await dbcontext.Categories.AddAsync(category);
            await dbcontext.SaveChangesAsync();

            return category;

        }
    }
}
