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
    class StudentControllerTest
    {
        StudentController studentController;
        Mock<IRepositoryHelper> mockStudentRepository;

        [SetUp]
        public void Setup()
        {
            mockStudentRepository = new Mock<IRepositoryHelper>();
            studentController = new StudentController(mockStudentRepository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            mockStudentRepository = null;
            studentController = null;
        }

        [Test, Order(1)]
        public void GetStudentTest()
        {
            IEnumerable<Student> expectedStudents;

            expectedStudents = StudentTestData.GetExpectedStudents();
            var expectedStudentsTask = Task.FromResult(expectedStudents);
            mockStudentRepository.Setup(m => m.Student.GetAllStudentsAsync()).Returns(expectedStudentsTask);

            OkObjectResult content = studentController.Get().Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Student>;
            var actualStudents = response.DataCollection;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(expectedStudentsTask.Result.Count(), actualStudents.ToList().Count);
        }

        [Test, Order(2)]
        public void GetStudentTestById()
        {
            Student expectedStudent;
            expectedStudent = StudentTestData.GetExpectedStudent();

            var expectedStudentTask = Task.FromResult(expectedStudent);

            mockStudentRepository.Setup(m => m.Student.GetStudentByIdAsync(expectedStudent.Id)).Returns(expectedStudentTask);

            OkObjectResult content = studentController.Get(expectedStudent.Id).Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Student>;
            var actualStudent = response.DataObject;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(expectedStudentTask.Result.Id, actualStudent.Id);
        }

        [Test, Order(3)]
        public void PostStudentTest()
        {
            Student addStudentTestData;
            addStudentTestData = StudentTestData.GetTestDataStudentAdd();
            mockStudentRepository.Setup(m => m.Student.CreateStudent(addStudentTestData)).Returns(true);

            OkObjectResult content = studentController.Post(addStudentTestData).Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Student>;
            var actualSaveSuccessMessage = response.Message;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(ResponseMessage.OnSuccessSaveMessage, actualSaveSuccessMessage);
        }

        [Test, Order(4)]
        public void PutStudentTest()
        {
            Student updateStudentTestData;
            updateStudentTestData = StudentTestData.GetTestDataStudentUpdate();
            mockStudentRepository.Setup(m => m.Student.UpdateStudent(updateStudentTestData)).Returns(true);

            OkObjectResult content = studentController.Put(updateStudentTestData).Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Student>;
            var actualUpdateSuccessMessage = response.Message;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(ResponseMessage.OnSuccessUpdateMessage, actualUpdateSuccessMessage);
        }


        [Test, Order(5)]
        public void DeleteStudentTest()
        {
            Student deleteStudentTestData;
            deleteStudentTestData = StudentTestData.GetTestDataStudentDelete();

            var expectedStudent = Task.FromResult(deleteStudentTestData);

            mockStudentRepository.Setup(m => m.Student.GetStudentByIdAsync(deleteStudentTestData.Id)).Returns(expectedStudent);
            mockStudentRepository.Setup(m => m.Student.DeleteStudent(deleteStudentTestData)).Returns(true);

            OkObjectResult content = studentController.Delete(deleteStudentTestData.Id).Result as OkObjectResult;
            HttpStatusCode httpStatusCode = (HttpStatusCode)content.StatusCode;

            var response = content.Value as ResponseModel<Student>;
            var actualDeleteSuccessMessage = response.Message;

            Assert.AreEqual(httpStatusCode, HttpStatusCode.OK);
            Assert.AreEqual(ResponseMessage.OnSuccessDeleteMessage, actualDeleteSuccessMessage);
        }
    }
}
