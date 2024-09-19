using DatabaseAccessLayer.Data;
using DatabaseAccessLayer.Entities;
using DatabaseAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Repositories.Implementation
{
    public class SectionRepository : ISectionRepository
    {
        private readonly AcademiaHubContext _context;

        public SectionRepository(AcademiaHubContext context)
        {
            _context = context;
        }

        public async Task AddSectionAsync(Section section)
        {
            var sectionFound = await GetSectionByIdAsync(section.SectionId);
            if (sectionFound == null)
            {
                await _context.Sections.AddAsync(section);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Section Already Exists");
            }

        }

        public async Task DeleteSectionByIdAsync(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section != null)
            {
                _context.Sections.Remove(section);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Section>> GetAllSectionsAsync()
        {
            return await _context.Sections.ToListAsync();
        }

        public async Task<Section> GetSectionByIdAsync(int id)
        {
            return await _context.Sections.FindAsync(id);
        }

        public async Task UpdateSectionAsync(Section section)
        {
            _context.Sections.Update(section);
            await _context.SaveChangesAsync();
        }
    }
}
