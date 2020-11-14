using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace YoyoMooc.StuManagement.Web.Pages
{
    public class DatabingdingDemoBase : ComponentBase
    {


        protected string Name { get; set; } = "张三";
        protected string Gender { get; set; } = "女";


        protected string Colour { get; set; } = "background-color:yellow";


        
    }
}
