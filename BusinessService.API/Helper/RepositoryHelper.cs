using BusinessService.API.DBContext;
using BusinessService.API.RepositoryCourse;
using BusinessService.API.RepositoryStudent;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.API.Helper
{
    public class RepositoryHelper : IRepositoryHelper
    {
        private RepositoryContext repositoryContext;
        private IStudentRepository studentRepository;
        private ICourseRepository courseRepository;
        public RepositoryHelper(RepositoryContext context)
        {
            repositoryContext = context;
        }

        public IStudentRepository Student
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new StudentRepository(repositoryContext);
                }
                return studentRepository;
            }
        }
        public ICourseRepository Course
        {
            get
            {
                if (courseRepository == null)
                {
                    courseRepository = new CourseRepository(repositoryContext);
                }
                return courseRepository;
            }
        }
        public async Task SaveAsync()
        {
            await repositoryContext.SaveChangesAsync();
        }
    }
}
