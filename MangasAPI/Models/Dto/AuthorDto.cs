namespace MangasAPI.Models.Dto
{
    public class AuthorDto
    {

        public string Name { get; set; }

        public List<MangaPostDto>? MangaPosts { get; set; }

    }
}
