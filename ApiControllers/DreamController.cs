using dreambot.Data;
using dreambot.Data.Entities;
using dreambot.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.ApiControllers
{
    [ApiController]
    [Route(template:"api/order")]
    public class DreamController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DreamController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public JsonResult Post([FromBody] checkStudent student)
        {
            var res = checkOption(student);
            return new JsonResult(res);
        }

        private object checkOption(checkStudent student)
        {
            var option = student.option;
            
            if (option == "Practice")
            {
                return checkStudentRegistered(student);
            }

            if (option == "registerNewUser")
            {
                return registerStudent(student);
            }

            return "action invalid";
        }

        private string checkStudentRegistered(checkStudent student)
        {
            var user = _context.Students.FirstOrDefault(s => s.whatsapp == student.number);
            if (user == null)
            {
                return "not found";
            }
            else
            {
                return "welcome back " + user.name;
            }
        }

        private object registerStudent(checkStudent student)
        {
            var user = new Student
            {
                whatsapp = student.number,
                name = student.option
            };

            var entity = _context.Students.Add(user);
            _context.SaveChanges();

            user = entity.Entity;

            return user.id;
        }
    }
}
