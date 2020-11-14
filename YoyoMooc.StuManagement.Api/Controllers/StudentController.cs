using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoyoMooc.StuManagement.Api.Repos;
using YoyoMooc.StuManagement.Models;
using YoyoMooc.StuManagement.Models.enums;

namespace YoyoMooc.StuManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController:ControllerBase
    {


        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudentes()
        {
            try
            {
                return Ok(await studentRepository.GetStudents());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "从数据库检索数据出错");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var result = await studentRepository.GetStudent(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "从数据库检索数据出错");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            { 

                if (student == null)
                    return BadRequest();


                // Add custom model validation error
                var model =await studentRepository.GetStudentByEmail(student.Email);

                if (model != null)
                {
                    ModelState.AddModelError("邮箱", "此电子邮件已经被注册了");
                    return BadRequest(ModelState);
                }



                var createdStudent = await studentRepository.AddStudent(student);

                return CreatedAtAction(nameof(GetStudent),
                    new { id = createdStudent.StudentId }, createdStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "创建新学生记录出错");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            try
            {
                if (id != student.StudentId)
                    return BadRequest("学生ID不匹配");

                var studentToUpdate = await studentRepository.GetStudent(id);

                if (studentToUpdate == null)
                    return NotFound($"未找到ID= {id}的学生");

                return await studentRepository.UpdateStudent(student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "数据更新错误");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await studentRepository.GetStudent(id);

                if (studentToDelete == null)
                {
                    return NotFound($"未找到ID= {id}的学生");
                }

                return await studentRepository.DeleteStudent(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "数据删除失败");
            }
        }


        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await studentRepository.Search(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "从数据库检索数据出错");
            }
        }


    }
}
