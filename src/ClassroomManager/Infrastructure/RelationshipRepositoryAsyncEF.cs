using App.Core.Entities;
using App.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class RelationshipRepositoryAsyncEF : IRelationshipRepositoryAsync
    {
        protected readonly ClassroomDbContext _dbContext;

        public RelationshipRepositoryAsyncEF(ClassroomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void AddRangeAsync(List<StudentLesson> idList)
        {
            await _dbContext.StudentLessons.AddRangeAsync(idList);
            await _dbContext.SaveChangesAsync();
        }

        public async void UpdateRangeAsync(List<StudentLesson> idList)
        {
             _dbContext.StudentLessons.UpdateRange(idList);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<StudentLesson> CheckLessonByIdAsync(long id)
        {
            return await _dbContext.StudentLessons.FirstOrDefaultAsync(t => t.LessonId == id);
        }

        
    }
}