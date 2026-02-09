using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguageTeacher.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<VerbalPair> Pairs { get; set; }

        public string DbPath { get; }

        public AppDbContext()
        {
            var path = Path.Combine(Environment.CurrentDirectory, ".files");
            Directory.CreateDirectory(path);

            DbPath = Path.Join(path, "AppContext.db");

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VerbalPair>().HasData(
                new VerbalPair() { Id = 1, Foreign = "repair", Translations = { "ремонтировать" } },
                new VerbalPair() { Id = 2, Foreign = "to paint", Translations = { "красить" } }
            );
        }
    }
}
