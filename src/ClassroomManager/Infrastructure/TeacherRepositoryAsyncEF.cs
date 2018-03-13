using App.Core.Entities;
using App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class TeacherRepositoryAsyncEF : RepositoryAsyncEF<Teacher>, ITeacherRepositoryAsync
    {
        public TeacherRepositoryAsyncEF(ClassroomDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Teacher> GetByUserAsync(string user)
        {
            return await _dbContext.Teachers
                .Include(t => t.Courses)
                .Include(l => l.Lessons)
                .FirstOrDefaultAsync(u => u.User == user);
        }

        public async Task<Teacher> GetByEmailAsync(string email)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}