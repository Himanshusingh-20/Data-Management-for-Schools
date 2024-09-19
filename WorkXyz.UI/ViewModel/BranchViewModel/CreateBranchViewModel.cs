using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.UI.Validation;

namespace WorkXyz.UI.ViewModel.BranchViewModel
{
    public class CreateBranchViewModel
    {
        [FirstLetterUpperCase]
        public string Name { get; set; }
    }
}
