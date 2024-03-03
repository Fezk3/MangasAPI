using MangasAPI.Models.Domain;
using MangasAPI.Models.Dto;
using MangasAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        public readonly IAuthorRepository authorRepo;

        public AuthorsController(IAuthorRepository authorRepo) 
        {
        
            this.authorRepo = authorRepo;

        }

        // create 
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody]CreateAuthorDto newAuthor)
        {

            var author = new Author { Name = newAuthor.Name };

            var createdAuthor = await authorRepo.CreateAsync(author);

            var newAuthordto = new AuthorDto
            {
                Name = createdAuthor.Name
            };

            return Ok(newAuthordto);

        }

        // get all
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await authorRepo.GetAllAsync();

            if (authors == null)
            {
                return BadRequest("No authors found");
            }

            return Ok(authors);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute]Guid id)
        {

            var searchedAuthor = await authorRepo.GetByIdAsync(id);

            if ( searchedAuthor == null )
            {
                return NotFound();
            }

            return Ok(searchedAuthor);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor([FromRoute]Guid id)
        {

            var toDeleteAuthor = await authorRepo.DeleteAsync(id);

            if (toDeleteAuthor is false)
            {
                return BadRequest("The requested author doesnt exist");
            }

            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] Author author, [FromRoute] Guid id)
        {

            var authorExists = await authorRepo.GetByIdAsync(id);

            if (authorExists == null)
            {
                return NotFound();
            }

            try
            {
                // Actualización del autor
                await authorRepo.UpdateAsync(author);

                // Puedes mapear a un DTO si es necesario
                // var authorDto = mapper.Map<AuthorDTO>(author);

                return Ok(author);
            }
            catch (Exception ex)
            {
                // Manejo de errores durante la actualización
                return StatusCode(500, "Error durante la actualización del autor.");
            }
        }


    }
}
