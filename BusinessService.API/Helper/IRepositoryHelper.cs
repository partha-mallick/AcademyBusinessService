using BusinessService.API.RepositoryCourse;
using BusinessService.API.RepositoryStudent;
using System.Threading.Tasks;

namespace BusinessService.API.Helper
{
    public interface IRepositoryHelper
    {
        IStudentRepository Student { get; }
        ICourseRepository Course { get; }
        Task SaveAsync();
    }
}
