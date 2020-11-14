using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoyoMooc.StuManagement.Models;

namespace YoyoMooc.StuManagement.Api.Services
{
    public interface IStudentService
    {
       

        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int id);
    }
}
