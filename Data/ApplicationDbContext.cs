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
        public DbSet<Course> Courses { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ConversationThread> ConversationThreads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            StudentEntityConfiguration.Configure(modelBuilder);
            CourseEntityConfiguration.Configure(modelBuilder);
            ConversationEntityConfiguration.Configure(modelBuilder);
            TeacherEntityConfiguration.Configure(modelBuilder);
        }
    }
}
