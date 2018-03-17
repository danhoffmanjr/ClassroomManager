using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
    public interface IRelationshipRepositoryAsync
    {
        void AddRangeAsync(List<StudentLesson> idList);
        void UpdateRangeAsync(List<StudentLesson> idList);
    }
}