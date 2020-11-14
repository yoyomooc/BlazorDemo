using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoMooc.StuManagement.Models;
using YoyoMooc.StuManagement.Models.enums;

namespace YoyoMooc.StuManagement.Api.Repos
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int studentId);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int studentId);

        Task<Student> GetStudentByEmail(string email);
        Task<IEnumerable<Student>> Search(string name, Gender? gender);
    }
}
