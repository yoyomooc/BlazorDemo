using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YoyoMooc.StuManagement.Models;
using YoyoMooc.StuManagement.Models.enums;

namespace YoyoMooc.StuManagement.Api.Data.seed
{

	/// <summary>
	/// 种子数据
	/// </summary>
	public static class SeedData
	{



		/// <summary>
		/// 初始化数据库和种子数据
		/// </summary>
		/// <param name="dbcontext"></param>

		public static IApplicationBuilder UseDataInitializer(
			 this IApplicationBuilder builder)
		{
			using (var scope = builder.ApplicationServices.CreateScope())
			{

				var dbcontext = scope.ServiceProvider.GetService<AppDbContext>();
				Console.WriteLine("开始执行迁移数据库...");
				dbcontext.Database.Migrate();
				Console.WriteLine("数据库迁移完成...");


				var s1 = new Student
				{
					StudentId = 1,
					StudentName = "张楚岚",
					Email = "chulan@yoyomooc.com",
					DateOfBrith = new DateTime(1980, 10, 5),
					Gender = Gender.Female,
					DepartmentId = 1,
					PhotoPath = "images/chulan.png"
				};

				Student s2 = new Student
				{
					StudentId = 2,
					StudentName = "张之维",
					Email = "zhiwei@yoyomooc.com",
					DateOfBrith = new DateTime(1981, 12, 22),
					Gender = Gender.Female,
					DepartmentId = 2,
					PhotoPath = "images/zhiwei.png"
				};

				Student s3 = new Student
				{
					StudentId = 3,
					StudentName = "冯宝宝",
					Email = "baobao@yoyomooc.com",
					DateOfBrith = new DateTime(1979, 11, 11),
					Gender = Gender.Male,
					DepartmentId = 1,
					PhotoPath = "images/baobao.png"
				};

				Student s4 = new Student
				{
					StudentId = 4,
					StudentName = "诸葛青",
					Email = "zgblue@yoyomooc.com",
					DateOfBrith = new DateTime(1982, 9, 23),
					Gender = Gender.Male,
					DepartmentId = 3,
					PhotoPath = "images/zgblue.png"
				};
				 
				// Code to seed data





				if (!dbcontext.Departments.Any())
				{

					Console.WriteLine("开始创建部门的种子数据中...");
					dbcontext.Departments.AddRange(
				new Department { DepartmentId = 1, DepartmentName = "哪都通" },
						new Department { DepartmentId = 3, DepartmentName = "武侯奇门" },
					new Department { DepartmentId = 2, DepartmentName = "龙虎山天师府" },
					new Department { DepartmentId = 4, DepartmentName = "编辑室" }


				
					);
					dbcontext.SaveChanges();
				}else


				if (!dbcontext.Students.Any())
				{
					Console.WriteLine("开始创建学生的种子数据中...");
					dbcontext.Students.AddRange(s1,s2,s3,s4
					);
					dbcontext.SaveChanges();

				}

				 
				else
				{
					Console.WriteLine("无需创建种子数据...");
				}


			}
			return builder;

		}


 




	}
}
