using Microsoft.AspNetCore.Mvc;
using WorkXyz.Entities;
using WorkXyz.Repositories.Interfaces;
using WorkXyz.UI.ViewModel.UserInfoViewModel;

namespace WorkXyz.UI.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(CreateUserInfoViewModel userInfo)
        {
            var userInfoFromDb = await _userRepo.Login(userInfo.UserName, userInfo.Password);
            HttpContext.Session.SetInt32("userId",userInfoFromDb.Id);
            HttpContext.Session.SetString("userName",userInfoFromDb.UserName);
            return RedirectToAction("Index","Branch");
        }
        [HttpPost]
        public async Task< IActionResult> Register(CreateUserInfoViewModel vm)
        {
            var userinfo = new UserInfo
            {
                UserName = vm.UserName,
                Password = vm.Password
            };
            await _userRepo.Register(userinfo);
            return RedirectToAction("Login");
        }

    }
}
