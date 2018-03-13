using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface ILessonRepositoryAsync : IRepositoryAsync<Lesson>
    {
        Task<List<Lesson>> ListByUserAsync(string user);
    }
}