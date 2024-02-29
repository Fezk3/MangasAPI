namespace MangasAPI.Models.Dto
{
    public class CreateMangaPostDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public CreateAuthorDto Author { get; set; }

        public List<CreateCategoryDto>? Categories { get; set; }
    }
}
