using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using YoyoMooc.StuManagement.Api.Services;
using YoyoMooc.StuManagement.Models;

namespace YoyoMooc.StuManagement.Web.Pages
{
    public class CreateOrEditStudentbase: ComponentBase
    {

        [Inject]
        public IStudentService StudentService { get; set; }
        [Inject]
        NavigationManager navigation{ get; set; }

        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public Student Student { get; set; } = new Student();

        protected override async Task OnInitializedAsync()
        {

            if (!string.IsNullOrWhiteSpace(Id))
            {


            Student= await  StudentService.GetStudent(int.Parse(Id));
                StateHasChanged();

            }
            else
            {
                Student = new Student();
            }

        }

        protected async Task HandleValidSubmit()
        {

            if (!string.IsNullOrWhiteSpace(Id))
            {
                var result= await StudentService.UpdateStudent(Student);


            }
            else
            {
                var result = await StudentService.CreateStudent(Student);

            }





            navigation.NavigateTo("/student");


        }
    }
}
