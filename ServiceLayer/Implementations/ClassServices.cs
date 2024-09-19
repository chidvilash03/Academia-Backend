using DatabaseAccessLayer.Entities;
using DatabaseAccessLayer.Repositories.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class ClassServices : IClassServices
    {
        private readonly IClassRepository _classRepository;

        public ClassServices(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task AddClassAsync(Class classDetails)
        {
            await _classRepository.AddClassAsync(classDetails);
        }

        public async Task DeleteClassByIdAsync(int id)
        {
            await _classRepository.DeleteClassByIdAsync(id);
        }

        public async Task<IEnumerable<Class>> GetAllClassDetailsAsync()
        {
            return await _classRepository.GetAllClassDetailsAsync();
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            return await _classRepository.GetClassByIdAsync(id);
        }

        public async Task UpdateClassAsync(Class classDetails)
        {
            await _classRepository.UpdateClassAsync(classDetails);
        }
    }
}
