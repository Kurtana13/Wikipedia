using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        //private readonly ApplicationDbContext _db;
        public UserController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            ;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password,loginModel.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                return View(loginModel);
            }

            return View(loginModel);

        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(userModel.UserName);
                if (user == null)
                {
                    user = new User
                    {
                        Name = userModel.Name,
                        UserName = userModel.UserName,
                        Email = userModel.Email,
                    };

                    var result = await userManager.CreateAsync(user, userModel.Password);

                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This User Name already exists");
                }
            }

            return View("Create");

        }
    }
}
