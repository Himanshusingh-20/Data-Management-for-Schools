using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkXyz.Repositories.Interfaces;
using WorkXyz.UI.ViewModel.DashBoard;


namespace WorkXyz.UI.ViewComponents
{
    public class DashBoardViewComponent: ViewComponent
    {
        private IBranchRepo _branchRepo;
        private ITeacherRepo _teacherRepo;
        private IStudentNewRepo _studentNewRepo;

        public DashBoardViewComponent(IBranchRepo branchRepo, ITeacherRepo teacherRepo, IStudentNewRepo studentNewRepo)
        {
            _branchRepo = branchRepo;
            _teacherRepo = teacherRepo;
            _studentNewRepo = studentNewRepo;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var vm = new DashBoard
            {
                TotalBranch = _branchRepo.GetAll().GetAwaiter().GetResult().Count(),
                TotalStudent = _studentNewRepo.GetAll().GetAwaiter().GetResult().Count(),
                TotalTeacher = _teacherRepo.GetAll().GetAwaiter().GetResult().Count(),
            };
            return View(vm);
        }
    }
}
