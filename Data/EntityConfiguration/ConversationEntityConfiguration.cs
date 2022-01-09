using dreambot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.EntityConfiguration
{
    public class ConversationEntityConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>(s =>
            {
                s.HasKey(e => e.id);
                s.Property(e => e.status)
                .IsRequired();
                s.Property(e => e.date)
                .IsRequired();
                s.Property(e => e.contents)
                .IsRequired();
                s.Property(e => e.studentId)
                .IsRequired();
                s.HasOne(e => e.student)
                .WithMany(u => u.conversations)
                .HasForeignKey(e => e.studentId);
                s.HasOne(e => e.teacher)
                .WithMany(u => u.conversations)
                .HasForeignKey(e => e.teacherId);
            });
        }
    }
}
