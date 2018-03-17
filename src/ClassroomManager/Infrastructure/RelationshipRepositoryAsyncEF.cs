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

        public async Task AddAsync(long studentId, long lessonId)
        {
            StudentLesson studentLesson = new StudentLesson
            {
                StudentId = studentId,
                LessonId = lessonId
            };

            await _dbContext.StudentLessons.AddAsync(studentLesson);
            await _dbContext.SaveChangesAsync();
        }

        //public async Task DeleteAsync(StudentLesson entity)
        //{
        //    _dbContext.StudentLessons.Remove(entity);
        //    await _dbContext.SaveChangesAsync();
        //}

        public void RemoveById(long studentId)
        {
            _dbContext.StudentLessons.RemoveRange(_dbContext.StudentLessons.Where(x => x.StudentId == studentId));
        }
    }
}