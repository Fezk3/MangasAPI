namespace MangasAPI.Models.Domain
{
    public class Category
    {

        // properties

        public Guid Id { get; set; }

        public string Name { get; set; }

        // relation many to many with MangaPost
        public List<MangaPost>? MangaPosts { get; set; }
    }
}
