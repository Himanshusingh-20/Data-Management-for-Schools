using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkXyz.Entities;
using WorkXyz.Repositories.Interfaces;
using WorkXyz.UI.ViewModel.SubjectViewModel;
using WorkXyz.UI.ViewModel.Utility;

namespace WorkXyz.UI.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectRepo subjectRepo;
        public IMapper _mapper;
        public SubjectsController(ISubjectRepo subjectRepo, IMapper mapper)
        {
            this.subjectRepo = subjectRepo;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, int pageNumber = 1, int pageSize=3, string searchText= null)
        {
            ViewData["CurrentSort"]=sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder)? "name_desc":"name_asc";
            ViewData["IdSortParam"] = sortOrder == "id_desc" ? "" : "id_desc";

           // List<SubjectViewModel> subjectlist = new List<SubjectViewModel>();
            var subjects = await subjectRepo.GetAll();
            var totalpage = 0;
            if (searchText != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchText=currentFilter;
            }
            ViewData["CurrentFilterData"]=searchText;

            if (!string.IsNullOrEmpty(searchText))
            {
                subjects= subjects.Where(x=>x.Name.Contains(searchText));
            }
            totalpage= subjects.ToList().Count();
            switch (sortOrder)
            {
                case "name_desc":subjects = subjects.OrderByDescending(x=>x.Name); break;
                case "name_asc": subjects=subjects.OrderBy(x=>x.Name); break;
                case "id_desc": subjects=subjects.OrderByDescending(x=>x.Id); break;
                    default:
                    subjects=subjects.OrderBy(x=>x.Id);break;

            }
            subjects = subjects.Skip((pageNumber-1)*pageSize).Take(pageSize);
           /* foreach (var subject in subjects)
            {
                subjectlist.Add(new SubjectViewModel
                {
                    Id = subject.Id,
                    Name = subject.Name,
                });
            } */
            var vm= _mapper.Map<List<SubjectViewModel>>(subjects);
            var pagedSubjectViewModel = new PagedSubjectViewModel
            {
                SubjectViewModelList = vm,
                PageInfo = new PageInfo
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems= totalpage,
                }
            };


            return View(pagedSubjectViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSubjectViewModel vm)
        {
            var subject = new Subjects
            {
                Name = vm.Name
            };
            await subjectRepo.Insert(subject);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var subject = await subjectRepo.GetById(id);
            var editsubject = new SubjectViewModel
            {
                Id = subject.Id,
                Name = subject.Name,
            };
            return View(editsubject);
        }
        [HttpPost]
        public async Task< IActionResult> Edit(SubjectViewModel subjects)
        {
            var subject = new Subjects
            {
                Name = subjects.Name,
            };
            await subjectRepo.Update(subject);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await subjectRepo.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
