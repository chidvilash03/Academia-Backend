using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IClassServices
    {
        public Task<IEnumerable<Class>> GetAllClassDetailsAsync();
        public Task<Class> GetClassByIdAsync(int id);
        public Task AddClassAsync(Class classDetails);
        public Task DeleteClassByIdAsync(int id);
        public Task UpdateClassAsync(Class classDetails);
    }
}
