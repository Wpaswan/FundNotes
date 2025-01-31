﻿using CommonLayer.Note;
using CommonLayer.User;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
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
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Collab> Collab { get; set; }
        public FundooDBContext(DbContextOptions options) : base(options)
        { }

        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
               .HasIndex(u => u.email)
               .IsUnique();

           
            modelBuilder.Entity<UserAddress>()
               .Property(b => b.Type)
               .HasDefaultValue("Home");


        }


    }
}

