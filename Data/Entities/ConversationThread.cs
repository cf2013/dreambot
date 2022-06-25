using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.Entities
{
    public class ConversationThread
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int studentId { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}
