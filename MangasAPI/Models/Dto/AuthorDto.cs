namespace MangasAPI.Models.Dto
{
    public class AuthorDto
    {

        public string Name { get; set; }

        // can be null
        public List<MangaPostDto>? MangaPosts { get; set; }

    }
}
