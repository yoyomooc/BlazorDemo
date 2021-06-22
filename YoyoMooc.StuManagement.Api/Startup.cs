using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using YoyoMooc.StuManagement.Api.Data;
using YoyoMooc.StuManagement.Api.Data.seed;
using YoyoMooc.StuManagement.Api.Repos;
using YoyoMooc.StuManagement.Models;

namespace YoyoMooc.StuManagement.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddDbContext<AppDbContext>(options =>

		   options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<IStudentRepository, StudentRepository>();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});


			if ((Configuration["INITDB"] ?? "false") == "true")
			{
				System.Console.WriteLine("准备数据库……");


				app.UseDataInitializer();


				System.Console.WriteLine("数据库初始化完成");
			}
			else
			{
				System.Console.WriteLine("启动 ASP.NET Core 深入浅出Docker...");
			}



		}
	}
}
