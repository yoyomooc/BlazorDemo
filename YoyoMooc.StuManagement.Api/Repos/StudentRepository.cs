using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YoyoMooc.StuManagement.Api.Data;
using YoyoMooc.StuManagement.Models;
using YoyoMooc.StuManagement.Models.enums;

namespace YoyoMooc.StuManagement.Api.Repos
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Student> AddStudent(Student student)
        {

            var result = await appDbContext.Students.AddAsync(student);


            await appDbContext.SaveChangesAsync();

            return result.Entity;



        }
        public async Task<IEnumerable<Student>> Search(string name, Gender? gender)
        {
            IQueryable<Student> query = appDbContext.Students;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.StudentName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
        public async Task<Student> DeleteStudent(int studentId)
        {


            var result = await appDbContext.Students.FirstOrDefaultAsync(a => a.StudentId == studentId);

            if (result != null)
            {
                appDbContext.Students.Remove(result);

                await appDbContext.SaveChangesAsync();


            }
            return result;
        }

        public async Task<Student> GetStudent(int studentId)
        {
            return await appDbContext.Students.Include(a => a.Department)
               .FirstOrDefaultAsync(e => e.StudentId == studentId);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await appDbContext.Students.ToListAsync();

        }
        public async Task<Student> GetStudentByEmail(string email)
        {
            return await appDbContext.Students
                .FirstOrDefaultAsync(e => e.Email == email);
        }
        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await appDbContext.Students
                .FirstOrDefaultAsync(e => e.StudentId == student.StudentId);

            if (result != null)
            {
                result.StudentName = student.StudentName;
                result.Email = student.Email;
                result.DateOfBrith = student.DateOfBrith;
                result.Gender = student.Gender;
                result.DepartmentId = student.DepartmentId;
                result.PhotoPath = student.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
