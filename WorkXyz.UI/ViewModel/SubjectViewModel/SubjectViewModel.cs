using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.UI.ViewModel.Utility;

namespace WorkXyz.UI.ViewModel.SubjectViewModel
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class PagedSubjectViewModel
    {
        public List<SubjectViewModel> SubjectViewModelList { get; set; }
        public PageInfo PageInfo { get; set; }
    }

}
