using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dreambot.Data.Entities;
using dreambot.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace dreambot.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            StudentEntityConfiguration.Configure(modelBuilder);
        }
    }
}
