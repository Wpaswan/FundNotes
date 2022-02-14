using CommonLayer.Note;
using CommonLayer.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class FundooDBContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Note { get; set; }
        public FundooDBContext(DbContextOptions options) : base(options)
        { }

        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
               .HasIndex(u => u.email)
               .IsUnique();

        }
    }
}

