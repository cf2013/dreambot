using dreambot.Data;
using dreambot.Services;
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
        private readonly IStudentService _studentService;
        public DreamController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckStudentRequest student)
        {
            var twilioServiceResponse = await _studentService.ProcessStudentRequestAsync(student);
            return new JsonResult(twilioServiceResponse.Message);
        }
    }
}
