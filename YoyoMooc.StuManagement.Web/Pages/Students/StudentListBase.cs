using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using YoyoMooc.StuManagement.Api.Services;
using YoyoMooc.StuManagement.Models;
using Microsoft.Extensions.Configuration;

using YoyoMooc.StuManagement.Models.enums;

namespace YoyoMooc.StuManagement.Web.Pages
{
    public class StudentListBase : ComponentBase
    {
        [Inject]
        public IStudentService _studentService { get; set; }

        [Parameter]
        public List<Student> Students { get; set; }

      

        protected override async Task OnInitializedAsync()
        {

           
            Students = (await _studentService.GetStudents()).ToList();
        }

        public string ToolTips { get; set; }

        /// <summary>
        /// 确认删除
        /// </summary>
        /// <param name="student"></param>
        /// <param name="isConfirm"></param>
        /// <returns></returns>
        protected async Task ConfirmDelete(Student student, bool isConfirm)
        {
            if (isConfirm)
            {
                await _studentService.DeleteStudent(student.StudentId);
                Students.Remove(student);
                StateHasChanged();
            }
        }




        protected async Task AddBatchStudents()
        {
            var students = await _studentService.GetStudents();

            if (students.ToList().Count > 50)
            {
                ToolTips = "学生人数已经超过50个了，不再新增，你可以删除部分学生信息后再尝试。";
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    var ran = new Random();
                    var randomVal = ran.Next(10, 855555);
                    Student s3 = new Student
                    {
                        StudentName = "冯宝宝" + randomVal,
                        Email = $"baobao{randomVal}@yoyomooc.com",
                        DateOfBrith = new DateTime(1979, 11, 11),
                        Gender = Gender.Male,
                        DepartmentId = 1,
                        PhotoPath = "images/baobao.png"
                    };
                    var res = await _studentService.CreateStudent(s3);

                    Students.Add(res);
                }
            }

            StateHasChanged();
        }
    }
}