using dreambot.Models.Dto;
using dreambot.Models.Helpers;
using dreambot.Models.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dreambot.Services
{
    public interface IStudentService
    {
        Task<ServiceResponse<StudentViewModel>> ProcessStudentRequestAsync(CheckStudentRequest student);
    }
}
