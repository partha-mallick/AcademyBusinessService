
using BusinessService.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BusinessService.API.Helper
{
    public class StudentResponseHelper 
    {
        private readonly IRepositoryHelper repositoryHelper;
        public StudentResponseHelper(IRepositoryHelper repoHelper)
        {
            repositoryHelper = repoHelper;
        }
        public async Task<ResponseModel<Student>> GetStudentsResponse()
        {
            return await Task.Run(async ()=>
            {
                ResponseModel<Student> responseModel = new ResponseModel<Student>();
                var serviceResponse = await repositoryHelper.Student.GetAllStudentsAsync();
                if (serviceResponse == null)
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.DataCollection = serviceResponse;
                }
                return responseModel;
            });
        }

        public async Task<ResponseModel<Student>> GetStudentResponse(int studentId)
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Student> responseModel = new ResponseModel<Student>();
                var serviceResponse = await repositoryHelper.Student.GetStudentByIdAsync(studentId);
                if (serviceResponse == null)
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                }
                else
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.DataObject = serviceResponse;
                }
                return responseModel;
            });
        }

        public async Task<ResponseModel<Student>> CreateStudent(Student student)
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Student> responseModel = new ResponseModel<Student>();

                bool isSuccess = repositoryHelper.Student.CreateStudent(student);
                await repositoryHelper.SaveAsync();

                if (isSuccess == true)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.DataObject = student;
                    responseModel.Message = ResponseMessage.OnSuccessSaveMessage;
                }
                else
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    responseModel.Message = ResponseMessage.OnErrorMessage;
                }
                return responseModel;
            });
        }

        public async Task<ResponseModel<Student>> UpdateStudent(Student student)
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Student> responseModel = new ResponseModel<Student>();

                bool isSuccess = repositoryHelper.Student.UpdateStudent(student);
                await repositoryHelper.SaveAsync();

                if (isSuccess == true)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.DataObject = student;
                    responseModel.Message = ResponseMessage.OnSuccessUpdateMessage;
                }
                else
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    responseModel.Message = ResponseMessage.OnErrorMessage;
                }
                return responseModel;
            });
        }

        public async Task<ResponseModel<Student>> DeleteStudent(int studentId)
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Student> responseModel = new ResponseModel<Student>();
                var student = await repositoryHelper.Student.GetStudentByIdAsync(studentId);

                if ((student != null) && (student.Id > 0))
                {
                    repositoryHelper.Student.DeleteStudent(student);
                    await repositoryHelper.SaveAsync();

                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.Message = ResponseMessage.OnSuccessDeleteMessage;
                }
                else
                {
                    responseModel.StatusCode = HttpStatusCode.BadRequest;
                    responseModel.Message = ResponseMessage.OnErrorMessage;
                }
                return responseModel;
            });
        }
    }


}
