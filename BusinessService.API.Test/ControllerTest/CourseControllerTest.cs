using BusinessService.API.Controllers;
using BusinessService.API.Helper;
using BusinessService.API.Models;
using BusinessService.API.Test.TestData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BusinessService.API.Test.ControllerTest
{
    class CourseControllerTest 
    {
        CourseController courseController;
        Mock<IRepositoryHelper> mockCourseRepository;

        [SetUp]
        public void Setup()
        {
            mockCourseRepository = new Mock<IRepositoryHelper>();
            courseController = new CourseController(mockCourseRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            mockCourseRepository = null;
            courseController = null;
        }

        [Test, Order(1)]
        public void GetCourseTest()
        {
            IEnumerable<Course> expectedCourses;

            expectedCourses = CourseTestData.GetExpectedCourses();
            var expectedCoursesTask = Task.FromResult(expectedCourses);
            mockCourseRepository.Setup(m => m.Course.GetAllCoursesAsync()).Returns(expectedCoursesTask);

            OkObjectResult content = courseController.Get().Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;
           
            var response = content.Value as ResponseModel<Course>;
            var actualCourses = response.DataCollection;
           
            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(expectedCoursesTask.Result.Count(), actualCourses.ToList().Count);
        }

        [Test, Order(2)]
        public void GetCourseTestById()
        {
            Course expectedCourse;
            expectedCourse = CourseTestData.GetExpectedCourse();

            var expectedCourseTask = Task.FromResult(expectedCourse);

            mockCourseRepository.Setup(m => m.Course.GetCourseByIdAsync(expectedCourse.Id)).Returns(expectedCourseTask);

            OkObjectResult content = courseController.Get(expectedCourse.Id).Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Course>;
            var actualCourse = response.DataObject;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(expectedCourseTask.Result.Id, actualCourse.Id);
        }

        [Test, Order(3)]
        public void PostCourseTest()
        {
            Course addCourseTestData;
            addCourseTestData = CourseTestData.GetTestDataCourseAdd();
            mockCourseRepository.Setup(m => m.Course.CreateCourse(addCourseTestData)).Returns(true);
            
            OkObjectResult content = courseController.Post(addCourseTestData).Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Course>;
            var actualSaveSuccessMessage = response.Message;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(ResponseMessage.OnSuccessSaveMessage, actualSaveSuccessMessage);
        }

        [Test, Order(4)]
        public void PutCourseTest()
        {
            Course updateCourseTestData;
            updateCourseTestData = CourseTestData.GetTestDataCourseUpdate();
            mockCourseRepository.Setup(m => m.Course.UpdateCourse(updateCourseTestData)).Returns(true);

            OkObjectResult content = courseController.Put(updateCourseTestData).Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Course>;
            var actualUpdateSuccessMessage = response.Message;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(ResponseMessage.OnSuccessUpdateMessage, actualUpdateSuccessMessage);
        }


        [Test, Order(5)]
        public void DeleteCourseTest()
        {
            Course deleteCourseTestData;
            deleteCourseTestData = CourseTestData.GetTestDataCourseDelete();

            var expectedCourse = Task.FromResult(deleteCourseTestData);

            mockCourseRepository.Setup(m => m.Course.GetCourseByIdAsync(deleteCourseTestData.Id)).Returns(expectedCourse);
            mockCourseRepository.Setup(m => m.Course.DeleteCourse(deleteCourseTestData)).Returns(true);

            OkObjectResult content = courseController.Delete(deleteCourseTestData.Id).Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Course>;
            var actualDeleteSuccessMessage = response.Message;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(ResponseMessage.OnSuccessDeleteMessage, actualDeleteSuccessMessage);
        }

    }
}
