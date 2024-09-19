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
    public class NewHostelRepository : IHostelRepository
    {
        public Task AddHostelAsync(Hostel hostel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHostelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hostel>> GetAllHostelDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Hostel> GetHostelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHostelAsync(Hostel hostel)
        {
            throw new NotImplementedException();
        }
    }
    public class HostelRepository : IHostelRepository
    {
        private readonly AcademiaHubContext _context;

        public HostelRepository(AcademiaHubContext context)
        {
            _context = context;
        }

        public async Task AddHostelAsync(Hostel hostel)
        {
            var hostelFound = await GetHostelByIdAsync(hostel.HostelId);
            if (hostelFound == null)
            {
                await _context.Hostels.AddAsync(hostel);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Hostel Already Exists");
            }

        }

        public async Task DeleteHostelByIdAsync(int id)
        {
            var hostel = await _context.Hostels.FindAsync(id);
            if (hostel != null)
            {
                _context.Hostels.Remove(hostel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Hostel>> GetAllHostelDetailsAsync()
        {
            return await _context.Hostels.ToListAsync();
        }

        public async Task<Hostel> GetHostelByIdAsync(int id)
        {
            return await _context.Hostels.FindAsync(id);
        }

        public async Task UpdateHostelAsync(Hostel hostel)
        {
            _context.Hostels.Update(hostel);
            await _context.SaveChangesAsync();
        }
    }
}
