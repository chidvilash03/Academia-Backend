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
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository _studentRepository;

        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task AddStudentAsync(Student student)
        {
            return _studentRepository.AddStudentAsync(student);
        }

        public Task DeleteStudentByIdAsync(int id)
        {
            return _studentRepository.DeleteStudentByIdAsync(id);
        }

        public Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return _studentRepository.GetAllStudentsAsync();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            return _studentRepository.GetStudentByIdAsync(id);
        }

        public Task UpdateStudentAsync(Student student)
        {
            return _studentRepository.UpdateStudentAsync(student);
        }
    }
}
