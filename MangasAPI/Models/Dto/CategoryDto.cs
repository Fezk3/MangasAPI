﻿namespace MangasAPI.Models.Dto
{
    public class CategoryDto
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        // list of manga posts with this category -> can be null
        public List<MangaPostDto>? MangaPosts { get; set; }

    }
}
