using BusinessService.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.API.Test.TestData
{
    public class CourseTestData
    {
        public static IEnumerable<Course> GetExpectedCourses()
        {
            List<Course> courses;
            courses = new List<Course>()
            {
                new Course()
                {
                    Id = 4,
                    Name = "Test Course",
                    Code = "TST01",
                    Description = "Test Course Global",
                    Languages = "Hindi,English,Bengali"
                },
                new Course()
                {
                    Id = 5,
                    Name = "Test Course2",
                    Code = "TST02",
                    Description = "Test Course Global2",
                    Languages = "Hindi,English,Tamil"
                }
            };
            return courses;
        }

        public static Course GetExpectedCourse()
        {
            Course course;
            course = new Course()
            {
                Id = 4,
                Name = "Test Course",
                Code = "TST01",
                Description = "Test Course Global",
                Languages = "Hindi,English,Bengali"
            };
            return course;
        }

        public static Course GetTestDataCourseAdd()
        {
            Course course;
            course = new Course()
            {
                Id = 0,
                Name = "Test Course",
                Code = "TST01",
                Description = "Test Course Global",
                Languages = "Hindi,English,Bengali"
            };
            return course;
        }

        public static Course GetTestDataCourseUpdate()
        {
            Course course;
            course = new Course()
            {
                Id = 3,
                Name = "Test Course",
                Code = "TST01",
                Description = "Test Course Global",
                Languages = "Hindi,English,Bengali"
            };
            return course;
        }

        public static Course GetTestDataCourseDelete()
        {
            Course course;
            course = new Course()
            {
                Id = 1,
                Name = "Test Course",
                Code = "TST01",
                Description = "Test Course Global",
                Languages = "Hindi,English,Bengali"
            };
            return course;
        }
    }
}
