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
        private readonly IStudentConversationService _conversationService;
        public DreamController(IStudentConversationService conversationService)
        {
            this._conversationService = conversationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckStudent student)
        {
            var conversationServiceResponse = await _conversationService.AddNewStudentAsync(student);
            return new JsonResult(conversationServiceResponse.Content.Name);
        }
    }
}
