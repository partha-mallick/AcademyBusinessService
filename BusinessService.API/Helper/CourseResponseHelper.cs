using BusinessService.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BusinessService.API.Helper
{
    public class CourseResponseHelper
    {
        private readonly IRepositoryHelper repositoryHelper;
        public CourseResponseHelper(IRepositoryHelper repoHelper)
        {
            repositoryHelper = repoHelper;
        }
        public async Task<ResponseModel<Course>> GetCoursesResponse()
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Course> responseModel = new ResponseModel<Course>();
                var serviceResponse = await repositoryHelper.Course.GetAllCoursesAsync();
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

        public async Task<ResponseModel<Course>> GetCourseResponse(int courseId)
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Course> responseModel = new ResponseModel<Course>();
                var serviceResponse = await repositoryHelper.Course.GetCourseByIdAsync(courseId);
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

        public async Task<ResponseModel<Course>> CreateCourse(Course course)
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Course> responseModel = new ResponseModel<Course>();
                bool isSuccess = repositoryHelper.Course.CreateCourse(course);
                await repositoryHelper.SaveAsync();

                if (isSuccess == true)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.DataObject = course;
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

        public async Task<ResponseModel<Course>> UpdateCourse(Course course)
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Course> responseModel = new ResponseModel<Course>();

                bool isSuccess = repositoryHelper.Course.UpdateCourse(course);
                await repositoryHelper.SaveAsync();

                if (isSuccess == true)
                {
                    responseModel.StatusCode = HttpStatusCode.OK;
                    responseModel.DataObject = course;
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

        public async Task<ResponseModel<Course>> DeleteCourse(int courseId)
        {
            return await Task.Run(async () =>
            {
                ResponseModel<Course> responseModel = new ResponseModel<Course>();
                var course = await repositoryHelper.Course.GetCourseByIdAsync(courseId);

                if ((course != null) && (course.Id > 0))
                {
                    repositoryHelper.Course.DeleteCourse(course);
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
