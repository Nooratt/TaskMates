using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using TaskDudes.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TaskDudes.Services
{
    public class TaskMatesContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Taski> Tasks { get; set; }
        public DbSet<Settings> Settings { get; set; }


        private const string DatabaseName = "taskMatesDatabase.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", DatabaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Taski>().ToTable("Tasks");
            modelBuilder.Entity<Settings>().ToTable("Settings");
        }
    }
}

