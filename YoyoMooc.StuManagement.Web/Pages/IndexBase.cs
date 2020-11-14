using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoyoMooc.StuManagement.Web.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private IConfiguration Config { get; set; }



        public string Hostname { get; set; }
        protected override async Task OnInitializedAsync()
        {


            Hostname = Config["HOSTNAME"];

        }

    }
}
