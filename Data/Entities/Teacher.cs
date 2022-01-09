using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.Entities
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string whatsapp { get; set; }
        public IList<Conversation> conversations { get; set; }
    }
}
