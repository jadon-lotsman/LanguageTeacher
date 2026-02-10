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
        public DbSet<VerbalEntry> Pairs { get; set; }

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

            modelBuilder.Entity<VerbalEntry>().HasData(
                new VerbalEntry() { Id = 1, Foreign = "to repair", Transcription= "[tu: rI'pea(r)]", Translations = { "ремонтировать" } },
                new VerbalEntry() { Id = 2, Foreign = "fuel", Transcription = "['fju:el]", Example= "We stopped to take on fuel.", Translations = { "топливо", "заправляться" } },
                new VerbalEntry() { Id = 3, Foreign = "pump", Translations = { "насос" } }
            );
        }
    }
}
