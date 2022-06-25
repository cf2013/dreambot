using dreambot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.Repositories
{
    public class ConversationThreadRepository:IConversationThreadRepository
    {
        private readonly ApplicationDbContext _context;

        public ConversationThreadRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<ConversationThread> GetConversationThread(int id)
        {
            return await _context
                .ConversationThreads
                .FirstOrDefaultAsync(s => s.id == id);
        }

        public async Task<bool> AddConversationThread(ConversationThread item)
        {
            var entity = await _context.ConversationThreads.AddAsync(item);
            await _context.SaveChangesAsync();
            //check successfully added?...
            return true;
        }
    }
}
