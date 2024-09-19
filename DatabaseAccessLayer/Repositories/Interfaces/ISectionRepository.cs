using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Repositories.Interfaces
{
    public interface ISectionRepository
    {
        public Task<IEnumerable<Section>> GetAllSectionsAsync();
        public Task<Section> GetSectionByIdAsync(int id);
        public Task AddSectionAsync(Section section);
        public Task DeleteSectionByIdAsync(int id);
        public Task UpdateSectionAsync(Section section);
    }
}
