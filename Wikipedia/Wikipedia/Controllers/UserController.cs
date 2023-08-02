using Microsoft.AspNetCore.Mvc;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                _db.User.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Create");
            }
        }
    }
}
