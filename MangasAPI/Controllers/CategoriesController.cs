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
                UrlHandle = request.UrlHandle,
            };

            // using the repository
            await categoryrepo.CreateAsync(category);

            // domain to dto
            CategoryDto response = new CategoryDto
            {

                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,

            };

            return Ok(response);

        }
    }
}
