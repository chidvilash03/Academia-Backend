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
    public class SectionServices : ISectionServices
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionServices(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task AddSectionAsync(Section section)
        {
            await _sectionRepository.AddSectionAsync(section);
        }

        public async Task DeleteSectionByIdAsync(int id)
        {
            await _sectionRepository.DeleteSectionByIdAsync(id);
        }

        public async Task<IEnumerable<Section>> GetAllSectionsAsync()
        {
            return await _sectionRepository.GetAllSectionsAsync();
        }

        public async Task<Section> GetSectionByIdAsync(int id)
        {
            return await _sectionRepository.GetSectionByIdAsync(id);
        }

        public async Task UpdateSectionAsync(Section section)
        {
            await _sectionRepository.UpdateSectionAsync(section);
        }
    }
}
