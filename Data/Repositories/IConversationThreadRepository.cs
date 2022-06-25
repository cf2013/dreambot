using dreambot.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.Repositories
{
    public interface IConversationThreadRepository
    {
        Task<ConversationThread> GetConversationThread(int id);
        Task<bool> AddConversationThread(ConversationThread item);
    }
}
