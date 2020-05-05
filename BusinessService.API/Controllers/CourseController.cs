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
    public class CourseController : ControllerBase
    {
        private readonly CourseResponseHelper courseResponseHelper;
        private readonly IRepositoryHelper repositoryHelper;
        public CourseController(IRepositoryHelper repo)
        {
            repositoryHelper = repo;
            courseResponseHelper = new CourseResponseHelper(repositoryHelper);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await courseResponseHelper.GetCoursesResponse());
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> Get(int studentId)
        {
            return Ok(await courseResponseHelper.GetCourseResponse(studentId));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseMessage.InValidModelMessage);
            }
            return Ok(await courseResponseHelper.CreateCourse(course));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ResponseMessage.InValidModelMessage);
            }
            return Ok(await courseResponseHelper.UpdateCourse(course));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int courseId)
        {
            return Ok(await courseResponseHelper.DeleteCourse(courseId));
        }
    }
}