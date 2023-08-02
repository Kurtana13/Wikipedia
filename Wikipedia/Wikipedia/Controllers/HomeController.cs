using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ViewResult Index()
        {
            return View(_db.User.ToList());
        }
    }
}