using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using YoyoMooc.StuManagement.Models;

namespace YoyoMooc.StuManagement.Api.Services
{
	public class StudentService : IStudentService
	{
		private readonly HttpClient httpClient;

		public StudentService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<Student> CreateStudent(Student student)
		{
			var result = await httpClient.PostJsonAsync<Student>($"api/student/", student);

			return result;
		}

		public async Task DeleteStudent(int id)
		{
			var result = await httpClient.DeleteAsync($"api/student/{id}");
		}

		public async Task<Student> UpdateStudent(Student student)
		{
			return await httpClient.PutJsonAsync<Student>($"api/student/{student.StudentId}", student);
		}

		public async Task<Student> GetStudent(int id)
		{
			return await httpClient.GetJsonAsync<Student>($"api/student/{id}");
		}

		public async Task<IEnumerable<Student>> GetStudents()
		{
			return await httpClient.GetJsonAsync<Student[]>("api/student");
		}
	}
}