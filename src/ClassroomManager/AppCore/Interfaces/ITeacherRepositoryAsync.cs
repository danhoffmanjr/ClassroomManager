using App.Core.Entities;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface ITeacherRepositoryAsync : IRepositoryAsync<Teacher>
    {
        Task<Teacher> GetByEmailAsync(string email);
    }
}