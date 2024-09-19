using Microsoft.AspNetCore.Mvc;
using WorkXyz.Entities;
using WorkXyz.Repositories.Interfaces;
using WorkXyz.UI.ViewModel;

namespace WorkXyz.UI.Controllers
{
    public class TeacherController : Controller
    {
        private  ITeacherRepo _teacherRepo;
        private  ISubjectRepo _subjectRepo;
        private string TeacherImage="TeacherImage";
        private IUtilityRepo _utilityRepo;


        public TeacherController(ITeacherRepo teacherRepo, ISubjectRepo subjectRepo, IUtilityRepo utilityRepo)
        {
            _teacherRepo = teacherRepo;
            _subjectRepo = subjectRepo;
            _utilityRepo = utilityRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<TeacherListViewModel> teacherlist =new List<TeacherListViewModel>();
            var teachers =await _teacherRepo.GetAll();
            foreach(var teacher in teachers)
            {
                teacherlist.Add(new TeacherListViewModel
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    ProfileImageUrl = teacher.ProfileImageUrl,

                });
            }
            return View(teacherlist);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var subject =await _subjectRepo.GetAll();
            var vm = new CreateTeacherViewModel();
            foreach (var item in subject)
            {
                vm.SubjectsList.Add(new CheckBoxTable
                {
                    Id = item.Id,
                    IsChecked = false,
                    Text = item.Name,
                });
            }
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherViewModel vm)
        {
            try
            {
                var teacher = new Teacher
                {
                    Name = vm.Name,
                };
                if (vm.ImagePath != null)
                {
                    teacher.ProfileImageUrl = await _utilityRepo.SaveImagePath(TeacherImage, vm.ImagePath);
                }
                var SelectedSubjectId = vm.SubjectsList.Where(x => x.IsChecked == true).Select(x => x.Id).ToList();
                foreach (var subjectid in SelectedSubjectId)
                {
                    teacher.TeacherSubjects.Add(new TeacherSubject
                    {
                        SubjectsId = subjectid
                    });
                }
                await _teacherRepo.Insert(teacher);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teacher= await _teacherRepo.GetById(id);
            var existingSubjectIds=teacher.TeacherSubjects.Select(x=>x.SubjectsId).ToList();

            var subject = await _subjectRepo.GetAll();
            var vm = new TeacherViewModel();
            vm.Name = teacher.Name;
            vm.Id = teacher.Id;
            vm.ProfileImage=teacher.ProfileImageUrl;
            foreach (var item in subject)
            {
                vm.SubjectsList.Add(new CheckBoxTable
                {
                    Id = item.Id,
                    IsChecked = existingSubjectIds.Contains(item.Id),
                    Text = item.Name,
                });
            }
            return View(vm);
        }
        [HttpPost]
        public async Task< IActionResult> Edit(TeacherViewModel vm)
        {
            try
            {
                var teacher=await _teacherRepo.GetById(vm.Id);
                var existingSubjectIds = teacher.TeacherSubjects.Select(x => x.SubjectsId).ToList();
                teacher.Name= vm.Name;
                if (vm.ImagePath != null)
                {
                    teacher.ProfileImageUrl = await _utilityRepo.EditFilePath(TeacherImage, vm.ImagePath, teacher.ProfileImageUrl);
                }
                var SelectedSubjectId = vm.SubjectsList.Where(x => x.IsChecked == true).Select(x => x.Id).ToList();

                var toAdd= SelectedSubjectId.Except(existingSubjectIds).ToList();
                var toRemove= existingSubjectIds.Except(SelectedSubjectId).ToList();
                foreach (var subjectid in toRemove)
                {
                    var teacherSubject = teacher.TeacherSubjects.Where(x => x.SubjectsId == subjectid).FirstOrDefault();
                    teacher.TeacherSubjects.Remove(teacherSubject);
                }

                foreach (var subjectid in toAdd)
                {
                    teacher.TeacherSubjects.Add(new TeacherSubject
                    {
                        SubjectsId = subjectid
                    });
                }
                await _teacherRepo.Update(teacher);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult > Delete(int id)
        {
            var teacher= await  _teacherRepo.GetById(id);
            await _utilityRepo.DeleteFilePath(teacher.ProfileImageUrl, TeacherImage);
            await _teacherRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
