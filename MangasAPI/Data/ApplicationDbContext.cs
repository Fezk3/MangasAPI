﻿using MangasAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MangasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet -> tables in the database

        public DbSet<MangaPost> MangaPosts { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
