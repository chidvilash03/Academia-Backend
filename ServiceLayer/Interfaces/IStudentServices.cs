using DatabaseAccessLayer.Entities;
using DatabaseAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IStudentServices
    {
        public Task<IEnumerable<Student>> GetAllStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task AddStudentAsync(Student student);
        public Task DeleteStudentByIdAsync(int id);
        public Task UpdateStudentAsync(Student student);

    }
}
