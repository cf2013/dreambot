using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.Entities
{
    public class Student
    {
        public int id { get; set; }
        public string whatsapp { get; set; }
        public string name { get; set; }
        public int currentCourse { get; set; }
        public string status { get; set; }
        public virtual IList<Conversation> conversations { get; set; }

    }
}
