using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using TaskDudes.Models;
using Xamarin.Essentials;

namespace TaskDudes.Services
{
    public class TaskMatesContext: DbContext
        {

            public DbSet<User> Users { get; set; }
            public DbSet<Taski> Tasks { get; set; }
            public DbSet<Settings> Settings { get; set; }

        private readonly string _connectionString;

        public TaskMatesContext(DbContextOptions<TaskMatesContext> options):base(options)
        {
           
        }

        public TaskMatesContext()
            {
                SQLitePCL.Batteries_V2.Init();

                this.Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "taskMates.db3");

                optionsBuilder
                    .UseSqlite($"Filename={dbPath}");
            }
        }
    }

