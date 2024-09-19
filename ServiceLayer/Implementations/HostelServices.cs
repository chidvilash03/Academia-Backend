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
    public class HostelServices : IHostelServices
    {
        private readonly IHostelRepository _hostelRepository;

        public HostelServices(IHostelRepository hostelRepository)
        {
            _hostelRepository = hostelRepository;
        }

        public async Task AddHostelAsync(Hostel hostel)
        {
            await _hostelRepository.AddHostelAsync(hostel);
        }

        public async Task DeleteHostelByIdAsync(int id)
        {
            await _hostelRepository.DeleteHostelByIdAsync(id);
        }

        public async Task<IEnumerable<Hostel>> GetAllHostelDetailsAsync()
        {
            return await _hostelRepository.GetAllHostelDetailsAsync();
        }

        public async Task<Hostel> GetHostelByIdAsync(int id)
        {
            return await _hostelRepository.GetHostelByIdAsync(id);
        }

        public async Task UpdateHostelAsync(Hostel hostel)
        {
            await _hostelRepository.UpdateHostelAsync(hostel);
        }
    }
}
