using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Repositories.Interfaces
{
    public interface IHostelRepository
    {
        public Task<IEnumerable<Hostel>> GetAllHostelDetailsAsync();
        public Task<Hostel> GetHostelByIdAsync(int id);
        public Task AddHostelAsync(Hostel hostel);
        public Task DeleteHostelByIdAsync(int id);
        public Task UpdateHostelAsync(Hostel hostel);
    }
}
