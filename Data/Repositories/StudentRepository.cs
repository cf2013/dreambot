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
        
        public async Task<Student> GetStudentByPhoneNumberAsync(string phoneNumber)
        {
            return await _context
                .Students
                .FirstOrDefaultAsync(s => s.whatsapp == phoneNumber);
        }

        public async Task<Student> AddNewStudentAsync(Student student)
        {
            var entity = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return entity.Entity; //whats Entity????
        }
    }
}
