using BusinessService.API.BaseRepository;
using BusinessService.API.DBContext;
using BusinessService.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessService.API.RepositoryStudent
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await GetAll()
               .OrderBy(p => p.Id)
               .ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await GetByCondition(p => p.Id.Equals(studentId))
                .FirstOrDefaultAsync();
        }

        public bool CreateStudent(Student student)
        {
            return Create(student);
        }

        public bool UpdateStudent(Student student)
        {
            return Update(student);
        }

        public bool DeleteStudent(Student student)
        {
            return Delete(student);
        }
    }
}
