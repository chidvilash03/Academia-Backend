using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Repositories.Interfaces
{
    public interface IClassRepository
    {
        public Task<IEnumerable<Class>> GetAllClassDetailsAsync();
        public Task<Class> GetClassByIdAsync(int id);
        public Task AddClassAsync(Class classDetails);
        public Task DeleteClassByIdAsync(int id);
        public Task UpdateClassAsync(Class classDetails);
    }
}
