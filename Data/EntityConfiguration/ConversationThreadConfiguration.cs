using dreambot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.EntityConfiguration
{
    public class ConversationThreadConfiguration
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversationThread>(s =>
            {
                s.HasKey(e => e.id);
            });
        }
    }
}
