using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dreambot.Data.Entities;
using dreambot.Data.Repositories;
using dreambot.Models.Dto;
using dreambot.Models.Enums;
using dreambot.Models.Helpers;
using dreambot.Models.viewModels;
using Microsoft.EntityFrameworkCore;

namespace dreambot.Services
{
    public class StudentConversationService:IStudentConversationService
    {
        private readonly IConversationThreadRepository _conversationThreadRepository;
        private readonly IStudentRepository _studentRepository;

        public StudentConversationService(IConversationThreadRepository conversationThreadRepository, IStudentRepository studentRepository)
        {
            this._conversationThreadRepository = conversationThreadRepository;
            this._studentRepository = studentRepository;
        }

        public async Task<ServiceResponse<StudentViewModel>> AddNewStudentAsync(CheckStudent student)
        {
            var serviceResponse = new ServiceResponse<StudentViewModel>();
            var studentEntity = new Student();

            /*
             * parse DTO checkStudent assing to studentEntity
             */
            var res = await CheckOption(student);

            serviceResponse.Content = new StudentViewModel(studentEntity);
            serviceResponse.ServiceResponseStatus = ServiceResponseStatus.Created;

            return serviceResponse;
        }

        private async Task<object> CheckOption(CheckStudent student)
        {
            var option = student.option;

            if (option.ToLower() == "practice")
            {
                return await checkStudentRegistered(student);
            }

            if (option == "registerNewUser")
            {
                return await registerStudent(student);
            }

            return "action invalid";
        }

        private async Task<string> checkStudentRegistered(CheckStudent student)
        {
            //var user = _studentRepository.Students.FirstOrDefault(s => s.whatsapp == student.number);
            var user = await _studentRepository.GetStudentByPhoneNumberAsync(student.number);

            if (user == null)
            {
                return "not found";
            }
            else
            {
                return "welcome back " + user.name;
            }
        }

        private async Task<object> registerStudent(CheckStudent student)
        {
            var user = new Student
            {
                whatsapp = student.number,
                name = student.option
            };

            return await _studentRepository.AddNewStudentAsync(user);
        }
    }
}
