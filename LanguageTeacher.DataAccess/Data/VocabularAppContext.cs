using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageTeacher.DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LanguageTeacher.DataAccess.Data
{
    public class VocabularAppContext : DbContext
    {
        public DbSet<VerbalPair> VerbalPairs { get; set; }

        public VocabularAppContext(DbContextOptions<VocabularAppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
