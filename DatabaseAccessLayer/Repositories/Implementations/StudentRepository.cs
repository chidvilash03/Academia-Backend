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
    public class StudentRepository : IStudentRepository
    {
        private readonly AcademiaHubContext _context;

        public StudentRepository(AcademiaHubContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            var studentFound = await GetStudentByIdAsync(student.EnrollmentNo);
            if (studentFound == null)
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Student Already Exists");
            }

        }

        public async Task DeleteStudentByIdAsync(int id)
        {
            var student = await _context.Students
            .Include(s => s.Hosteler)
            .Include(s => s.Parent)
            .Include(s => s.Guardian)
            .FirstOrDefaultAsync(s => s.EnrollmentNo == id);

            if (student == null)
            {
                throw new Exception("Student not found");
            }

            // Handle related entities
            if (student.Hosteler != null)
            {
                _context.Hostelers.Remove(student.Hosteler);
            }

            // Remove the student
            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.Include(s => s.Parent).Include(s => s.Guardian).Include(s => s.Hosteler).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.Include(s => s.Parent).Include(s => s.Guardian).Include(s => s.Hosteler).FirstOrDefaultAsync(s => s.EnrollmentNo == id);

        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
