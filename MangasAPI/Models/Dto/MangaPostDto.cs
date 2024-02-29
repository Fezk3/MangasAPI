namespace MangasAPI.Models.Dto
{
    public class MangaPostDto
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public AuthorDto Author { get; set; }

        public List<CategoryDto>? Categories { get; set; }

    }
}
