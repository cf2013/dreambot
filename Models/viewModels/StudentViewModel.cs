using dreambot.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Models.viewModels
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
        }

        public StudentViewModel(Student student)
        {
            Id = student.id;
            Whatsapp = student.whatsapp;
            Name = student.name;
            CurrentCourse = student.currentCourse;
            Status = student.status;
            Conversations = student.conversations;
        }

        public int Id { get; set; }
        public string Whatsapp { get; set; }
        public string Name { get; set; }
        public int CurrentCourse { get; set; }
        public string Status { get; set; }
        public IList<Conversation> Conversations { get; set; }
    }
}
