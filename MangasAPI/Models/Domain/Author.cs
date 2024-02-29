namespace MangasAPI.Models.Domain
{
    public class Author
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        // relation one to many with MangaPost
        public List<MangaPost> MangaPosts { get; set; }

    }
}
