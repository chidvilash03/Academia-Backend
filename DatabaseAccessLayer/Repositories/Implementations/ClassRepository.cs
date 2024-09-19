using DatabaseAccessLayer.Data;
using DatabaseAccessLayer.Entities;
using DatabaseAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DatabaseAccessLayer.Repositories.Implementation
{
    public class ClassRepository : IClassRepository
    {
        private readonly AcademiaHubContext _context;

        public ClassRepository(AcademiaHubContext context)
        {
            _context = context;
        }

        public async Task AddClassAsync(Class classDetails)
        {
            var classFound = await GetClassByIdAsync(classDetails.ClassId);
            if (classFound == null)
            {
                await _context.Classes.AddAsync(classDetails);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Class Already Exists");
            }
        }

        public async Task DeleteClassByIdAsync(int id)
        {
            var classDetails = await _context.Classes.FindAsync(id);
            if (classDetails != null)
            {
                _context.Classes.Remove(classDetails);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Class>> GetAllClassDetailsAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task UpdateClassAsync(Class classDetails)
        {
            _context.Classes.Update(classDetails);
            await _context.SaveChangesAsync();
        }
    }
}
