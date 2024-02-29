namespace MangasAPI.Models.Domain
{
    public class MangaPost
    {

        // properties
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public Boolean IsVisible { get; set; }

        // relation one to many with Author

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        
        // relation many to many with Category

        public List<Category> Categories { get; set; }

    }
}
