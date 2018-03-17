using App.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IStudentRepositoryAsync : IRepositoryAsync<Student>
    {
        Task<List<Student>> ListByUserAsync(string user);
    }
}