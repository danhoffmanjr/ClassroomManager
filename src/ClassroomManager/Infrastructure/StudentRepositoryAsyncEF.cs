using App.Core.Entities;
using App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class StudentRepositoryAsyncEF : RepositoryAsyncEF<Student>, IStudentRepositoryAsync
    {
        public StudentRepositoryAsyncEF(ClassroomDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Student> GetByUserAsync(string user)
        {
            return await _dbContext.Students
                .Include(t => t.StudentLessons)
                .FirstOrDefaultAsync(u => u.User == user);
        }

        public async Task<List<Student>> ListByUserAsync(string user)
        {
            return await _dbContext.Students
                .Include(t => t.Teacher)
                .Include(s => s.StudentLessons)
                .Where(q => q.User == user)
                .ToListAsync();
        }
    }
}