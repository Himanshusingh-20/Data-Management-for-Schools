using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkXyz.Entities;
using WorkXyz.Repositories.Interfaces;
using WorkXyz.UI.ViewModel.BranchViewModel;

namespace WorkXyz.UI.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchRepo _branchRepo;
        private  IMapper _mapper;

        public BranchController(IBranchRepo branchRepo, IMapper mapper)
        {
            _branchRepo = branchRepo;
            _mapper = mapper;
        }

        public async Task< IActionResult> Index()
        {
            if(HttpContext.Session.GetInt32("userId")!= null)
            {
              //  List<BranchViewModel> branchList = new List<BranchViewModel>();
                var branchs = await _branchRepo.GetAll();
                var branchList=  _mapper.Map<List<BranchViewModel>>(branchs);
               /* foreach (var branch in branchs)
                {
                    branchList.Add(new BranchViewModel
                    {
                        Id = branch.Id,
                        Name = branch.Name
                    });

                }*/
                return View(branchList);
            }
            return RedirectToAction("Login","Auth");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Create(CreateBranchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                /*var branch = new Branch
                {
                    Name = vm.Name
                };*/
                var branch = _mapper.Map<Branch>(vm);
              int result=  await _branchRepo.Insert(branch);
                if (result>0)
                {
                    TempData["Success"] = "Record Inserted";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Error occured";
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {
            var branch=  await  _branchRepo.GetById(id);
            /* var vm= new BranchViewModel { 
                 Id = department.Id,
                 Name= department.Name,
             };*/
            var vm = _mapper.Map<BranchViewModel>(branch);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BranchViewModel vm)
        {
           /* var branch=new Branch{ 
                Id = vm.Id ,
                Name = vm.Name ,
            };*/
           var branch= _mapper.Map<Branch>(vm);
            await _branchRepo.Update(branch);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task< IActionResult> Delete(int id)
        {
            await _branchRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
