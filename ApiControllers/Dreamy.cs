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
    public class Dreamy : ControllerBase
    {
        [HttpPost]
        public JsonResult Post([FromBody] checkStudent student)
        {
            var res = checkStudentRegistered(student);
            return new JsonResult(res);
        }

        private object checkStudentRegistered(checkStudent student)
        {

            return new { status = "found", name = "" };
        }
    }
}
