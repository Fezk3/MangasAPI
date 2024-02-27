namespace MangasAPI.Models.Domain
{
    public class MangaPost
    {

        // properties
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Content { get; set; }

        public string FeaturedImage { get; set; }

        public string UrlHandle { get; set; }

        public string Author { get; set; }

        public DateTime PublishedDate { get; set; }

        public Boolean IsVisible { get; set; }


    }
}
