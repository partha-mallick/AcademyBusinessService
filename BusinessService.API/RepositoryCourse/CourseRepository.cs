using BusinessService.API.BaseRepository;
using BusinessService.API.DBContext;
using BusinessService.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.API.RepositoryCourse
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await GetAll()
               .OrderBy(p => p.Id)
               .ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            return await GetByCondition(p => p.Id.Equals(courseId))
                .FirstOrDefaultAsync();
        }

        public bool CreateCourse(Course course)
        {
           return Create(course);
        }

        public bool UpdateCourse(Course course)
        {
            return Update(course);
        }

        public bool DeleteCourse(Course course)
        {
            return Delete(course);
        }
    }
}
