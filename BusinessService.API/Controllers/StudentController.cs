using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessService.API.Helper;
using BusinessService.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentResponseHelper studentResponseHelper;
        private readonly IRepositoryHelper repositoryHelper;

        public StudentController(IRepositoryHelper repo)
        {
            repositoryHelper = repo;
            studentResponseHelper = new StudentResponseHelper(repositoryHelper);
        }
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await studentResponseHelper.GetStudentsResponse());
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> Get(int studentId)
        {
            return Ok(await studentResponseHelper.GetStudentResponse(studentId));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseMessage.InValidModelMessage);
            }
            return Ok(await studentResponseHelper.CreateStudent(student));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseMessage.InValidModelMessage);
            }
            return Ok(await studentResponseHelper.UpdateStudent(student));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int studentId)
        {
            return Ok(await studentResponseHelper.DeleteStudent(studentId));
        }
    }
}