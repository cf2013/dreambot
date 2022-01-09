using dreambot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<Student> GetStudentByPhoneNumberAsync(int phoneNumber)
        {
            return await _context.Students.FirstOrDefaultAsync(e => e.whatsapp == phoneNumber);
        }
    }
}
