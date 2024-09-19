using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkXyz.Entities;
using WorkXyz.Repositories.Interfaces;
using WorkXyz.UI.ViewModel.BranchViewModel;
using WorkXyz.UI.ViewModel.StudentViewModel;

namespace WorkXyz.UI.Controllers
{
    public class StudentNewController : Controller
    {
        private readonly IStudentNewRepo _studentNewRepo;
        private readonly IBranchRepo _branchRepo;

        public StudentNewController(IStudentNewRepo studentNewRepo, IBranchRepo branchRepo)
        {
            _studentNewRepo = studentNewRepo;
            _branchRepo = branchRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            var employee = await _studentNewRepo.GetAll();
            foreach(var employe in employee)
            {
                studentList.Add(new StudentViewModel
                {
                    Id = employe.Id,
                    Name = employe.Name,
                    BranchName = employe.Branch.Name
                });
            }
            return View(studentList);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var branch = await _branchRepo.GetAll();
            ViewBag.BranchList = new SelectList(branch, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel vm)
        {
            var student = new StudentsNew
            {
                Name = vm.Name,
                BranchId = vm.BranchId
            };
            await _studentNewRepo.Insert(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var studentNew= await _studentNewRepo.GetById(id);
            var editStudent = new EditStudentViewModel
            {
                Id = studentNew.Id,
                Name = studentNew.Name,
                BranchId = studentNew.BranchId
            };
            var branch =await _branchRepo.GetAll();
            ViewBag.BranchList = new SelectList(branch, "Id", "Name");
            return View(editStudent);
        }
        [HttpPost]
        public async Task< IActionResult> Edit(EditStudentViewModel vm)
        {
            var editstudent = new StudentsNew
            {
                Id = vm.Id,
                Name = vm.Name,
                BranchId = vm.BranchId

            };
            await _studentNewRepo.Update(editstudent);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async  Task<IActionResult> Delete(int id)
        {
            await _studentNewRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
