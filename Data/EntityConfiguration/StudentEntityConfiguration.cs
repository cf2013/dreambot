using dreambot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.EntityConfiguration
{
    public class StudentEntityConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s =>
            {
                s.HasKey(e => e.id);
                s.Property(e => e.name)
                .IsRequired();
                s.Property(e => e.whatsapp)
                .IsRequired();
            });
        }
    }
}
