using CommonLayer.Note;
using CommonLayer.User;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace RepositoryLayer.Services
{
    public class FundooDBContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Labels> Labels { get; set; }
        public FundooDBContext(DbContextOptions options) : base(options)
        { }

        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
               .HasIndex(u => u.email)
               .IsUnique();

            //   modelBuilder.Entity<Labels>()
            //   .HasOne(u => u.Users)
            //   .WithMany()
            //   .HasForeignKey(u => u.userId)
            ////   .OnDelete(DeleteBehavior.Cascade); //Cascade behaviour
            ////   modelBuilder.Entity<Labels>()
            ////.HasOne(u => u.notes)
            ////.WithMany()
            ////.HasForeignKey(u => u.NoteID)
            //.OnDelete(DeleteBehavior.Cascade); //Cascade behaviour


        }


    }
}

