using BusinessService.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessService.API.Test.TestData
{
    class StudentTestData
    {
        public static IEnumerable<Student> GetExpectedStudents()
        {
            List<Student> students;
            students = new List<Student>()
            {
                new Student()
                {
                    Id = 4,
                    Name = "John",
                    Dob = DateTime.UtcNow,
                    Gender = "Male"
                },
                new Student()
                {
                    Id = 5,
                    Name = "Joe",
                    Dob = DateTime.UtcNow,
                    Gender = "Male"
                }
            };
            return students;
        }

        public static Student GetExpectedStudent()
        {
            Student student;
            student = new Student()
            {
                Id = 5,
                Name = "Joe",
                Dob = DateTime.UtcNow,
                Gender = "Male"
            };
            return student;
        }

        public static Student GetTestDataStudentAdd()
        {
            Student student;
            student = new Student()
            {
                Id = 0,
                Name = "Lisa",
                Dob = DateTime.UtcNow,
                Gender = "Female"
            };
            return student;
        }

        public static Student GetTestDataStudentUpdate()
        {
            Student student;
            student = new Student()
            {
                Id = 1,
                Name = "Henry",
                Dob = DateTime.UtcNow,
                Gender = "Male"
            };
            return student;
        }

        public static Student GetTestDataStudentDelete()
        {
            Student student;
            student = new Student()
            {
                Id = 2,
                Name = "Luis",
                Dob = DateTime.UtcNow,
                Gender = "Male"
            };
            return student;
        }
    }
}
