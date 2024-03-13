using GitHub.Database;
using GitHub.Filters.StudentFilters;
using GitHub.Models;
using Microsoft.EntityFrameworkCore;

namespace GitHub.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByIdAsync(StudentIdFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByGroupIdAsync(StudentGroupId filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudNameee(StudName filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Student[]> GetStudNameee(StudName filter, CancellationToken cancellationToken = default)
        {
            var group = _dbContext.Set<Group>().Where(w => w.GroupId == filter.GroupId).ToArrayAsync(cancellationToken);
            var students = _dbContext.Set<Student>().Where(w => w.FirstName == filter.FirstName).ToArrayAsync(cancellationToken);

            return students;
        }




        public Task<Student[]> GetStudentsByIdAsync(StudentIdFilter filter, CancellationToken cancellationToken = default)
        {
            var studentsid = _dbContext.Set<Student>().Where(w => w.StudentId == filter.StudentId).ToArrayAsync(cancellationToken);

            return studentsid;
        }

        public Task<Student[]> GetStudentsByNameAsync(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var studentsid = _dbContext.Set<Student>().Where(w => w.FirstName == filter.FirstName).ToArrayAsync(cancellationToken);

            return studentsid;
        }
        public Task<Student[]> GetStudentsByGroupIdAsync(StudentGroupId filter, CancellationToken cancellationToken = default)
        {
            var studentsid = _dbContext.Set<Student>().Where(w => w.GroupId == filter.GroupId).ToArrayAsync(cancellationToken);

            return studentsid;
        }




    }
}