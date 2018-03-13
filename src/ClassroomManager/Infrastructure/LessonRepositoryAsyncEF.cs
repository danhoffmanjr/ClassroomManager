using App.Core.Entities;
using App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class LessonRepositoryAsyncEF : RepositoryAsyncEF<Lesson>, ILessonRepositoryAsync
    {
        public LessonRepositoryAsyncEF(ClassroomDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Lesson> GetByUserAsync(string user)
        {
            return await _dbContext.Lessons
                .Include(c => c.Course)
                .Include(t => t.Teacher)
                .Include(l => l.Sections)
                .Include(s => s.StudentLessons)
                .Include(a => a.Assignments)
                .Include(f => f.Attachments)
                .FirstOrDefaultAsync(u => u.User == user);
        }

        public override async Task<Lesson> GetByIdAsync(long id)
        {
            return await _dbContext.Lessons
                .Include(c => c.Course)
                .Include(t => t.Teacher)
                .Include(l => l.Sections)
                .Include(s => s.StudentLessons)
                .Include(a => a.Assignments)
                .Include(f => f.Attachments)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Lesson>> ListByUserAsync(string user)
        {
            return await _dbContext.Lessons
                .Include(c => c.Course)
                .Include(t => t.Teacher)
                .Include(l => l.Sections)
                .Include(s => s.StudentLessons)
                .Include(a => a.Assignments)
                .Include(f => f.Attachments)
                .Where(q => q.User == user)
                .ToListAsync();
        }
    }
}