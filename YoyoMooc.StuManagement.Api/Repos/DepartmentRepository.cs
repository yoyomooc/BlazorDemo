using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoyoMooc.StuManagement.Api.Data;
using YoyoMooc.StuManagement.Models;

namespace YoyoMooc.StuManagement.Api.Repos
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Department GetDepartment(int departmentId)
        {
            return appDbContext.Departments
                .FirstOrDefault(d => d.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return appDbContext.Departments;
        }
    }
}
