using MangasAPI.Data;
using MangasAPI.Models.Domain;
using MangasAPI.Models.Dto;
using MangasAPI.Repositories.Implementation;
using MangasAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangasAPI.Controllers
{

    // https://localhost:5001/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository categoryrepo;

        public CategoriesController(ICategoryRepository categoryrepo)
        {
            this.categoryrepo = categoryrepo;
        }

        // Post
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto request)
        {

            // Map dto to domain model
            if (request == null)
            {
                return BadRequest();
            }

            var category = new Category
            {
                Name = request.Name,
                MangaPosts = new List<MangaPost>(),
            };

            // using the repository
            await categoryrepo.CreateAsync(category);

            // domain to dto
            CategoryDto response = new CategoryDto
            {

                Id = category.Id,
                Name = category.Name,
                MangaPosts = category.MangaPosts.Select(mp => new MangaPostDto
                {
                    Title = mp.Title,
                    Author = new AuthorDto
                    {
                        Name = mp.Author.Name
                    }
                }).ToList()

            };

            return Ok(response);

        }

        // Get all
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {

            var categories = await categoryrepo.GetAllAsync();

            if (categories == null)
            {
                return NotFound();
            }

            // domain to dto
            var response = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                MangaPosts = c.MangaPosts.Select(mp => new MangaPostDto
                {
                    Title = mp.Title,
                    Author = new AuthorDto
                    {
                        Name = mp.Author.Name
                    }
                }).ToList()
            });

            return Ok(response);

        }

        // Get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {

            var category = await categoryrepo.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            // domain to dto
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                MangaPosts = category.MangaPosts.Select(mp => new MangaPostDto
                {
                    Title = mp.Title,
                    Author = new AuthorDto
                    {
                        Name = mp.Author.Name
                    }
                }).ToList()
            };

            return Ok(response);

        }

        // Put
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] Category request)
        {

            var category = await categoryrepo.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            // Map dto to domain model
            category.Name = request.Name;

            // using the repository
            await categoryrepo.UpdateAsync(category);

            // domain to dto
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                MangaPosts = category.MangaPosts.Select(mp => new MangaPostDto
                {
                    Title = mp.Title,
                    Author = new AuthorDto
                    {
                        Name = mp.Author.Name
                    }
                }).ToList()
            };

            return Ok(response);

        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {

            var category = await categoryrepo.DeleteAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
