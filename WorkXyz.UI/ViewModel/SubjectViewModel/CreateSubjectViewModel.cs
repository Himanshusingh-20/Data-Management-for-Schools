using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.UI.ViewModel.SubjectViewModel
{
    public class CreateSubjectViewModel
    {
        [RegularExpression("^[A-Z a-z]+$",ErrorMessage ="The special character are not allowed ie.number")]
        public string Name { get; set; }
    }
}
