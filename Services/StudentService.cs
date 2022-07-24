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
    public class StudentService:IStudentService
    {
        private readonly IConversationThreadRepository _conversationThreadRepository;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IConversationThreadRepository conversationThreadRepository, IStudentRepository studentRepository)
        {
            this._conversationThreadRepository = conversationThreadRepository;
            this._studentRepository = studentRepository;
        }

        /*
         * This takes all request and route accordingly.
         */
        public async Task<ServiceResponse<StudentViewModel>> ProcessStudentRequestAsync(CheckStudentRequest studentRequest)
        {
            var serviceResponse = new ServiceResponse<StudentViewModel>();

            // First check request comes from a known whatsapp number
            // assign request to a specific student
            
            var requestResult = await serveRequest(studentRequest);

            //provide response from specific service using specific student or failHandled status

            if (requestResult.requestOk == false)
            {
                serviceResponse.ServiceResponseStatus = ServiceResponseStatus.FailHandled;
            }

            serviceResponse.Content = requestResult;

            return serviceResponse;
        }

        private async Task<StudentViewModel> serveRequest(CheckStudentRequest studentRequest)
        {
            var requestOption = studentRequest.option.ToLower();
            var requestNumber = studentRequest.number;
            StudentViewModel studentViewModel = null;

            if (requestOption == "practice" || requestOption == "start_conversation")
            {
                var student = new Student();
                student = await GetStudent(requestNumber);
                studentViewModel = new StudentViewModel(student);

                if (!string.IsNullOrEmpty(studentViewModel.Name))
                {
                    startChatBotLoop(studentViewModel);
                    studentViewModel.Info = "Thanks for using Dream English products";
                }
                else 
                {
                    studentViewModel.Info = "User not found please register first!";
                }
            }

            if (requestOption == "info")
            {
                var student = new Student();
                student = await GetStudent(requestNumber);
                
                if (student != null)
                {
                    studentViewModel = new StudentViewModel(student);
                    studentViewModel.Info = "Dream bot is a product from DreamEnglish Trademark, visit www.dreamenglish.com.mx";
                }
                else
                {
                    studentViewModel.Info = "User not found please register first!";
                    studentViewModel.requestOk = false;
                }
            }

            if (requestOption == "registerNewUser")
            {
                var student = new Student();
                student = await GetStudent(requestNumber);

                if (student == null)
                {
                    var newStudent = await registerStudent(studentRequest);
                    studentViewModel = new StudentViewModel(newStudent);
                }
            }

            return studentViewModel;
        }

        private object startChatBotLoop(StudentViewModel student)
        {
            var conver = new ConversationThread();
            conver.question = "hallo";
            return conver;
        }

        private async Task<Student> GetStudent(string studentNumber)
        {
            var user = await _studentRepository.GetStudentByPhoneNumberAsync(studentNumber);
            return user;
        }

        private async Task<Student> registerStudent(CheckStudentRequest student)
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
