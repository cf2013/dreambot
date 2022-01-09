using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.Entities
{
    public class Conversation
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public string contents { get; set; }
        public string seed { get; set; }
        public string feedback { get; set; }
        public int studentId { get; set; }
        public virtual Student student { get; set; }
        public int teacherId { get; set; }
        public virtual Teacher teacher { get; set; }
        public DateTime teacherFeedbackDate { get; set; }
        public string teacherFeedback { get; set; }

    }
}
