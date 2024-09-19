using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.UI.ViewModel
{
    public class TeacherListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[Display(Name="Profile Image")]
        public string? ProfileImageUrl { get; set; }

    }
}
