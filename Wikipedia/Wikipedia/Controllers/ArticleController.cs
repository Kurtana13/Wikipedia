using Microsoft.AspNetCore.Mvc;
using Wikipedia.Data;
using Wikipedia.Models;

namespace Wikipedia.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ArticleController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ViewResult Index()
        {
            var article = new ArticleCommentViewModel(_db.Article.ToList());
            return View(article);
        }

        [HttpPost]
        public ActionResult Index(Comment comment, Article article)
        {
            if (ModelState.IsValid)
            {
                Comment validComment = comment;
                validComment.Article = article;
                validComment.User = article.User;
                var validArticle = _db.Article.Find(article.Id);
                validArticle.Comments.Add(validComment);
                _db.Comment.Add(validComment);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Article article)
        {

            if(ModelState.IsValid)
            {
                User? user = _db.User.Find(article.UserId);
                if (user != null)
                {
                    article.User = user;
                    _db.Article.Add(article);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User doesn't exists!");
                }
            }
            return View();
        }
    }
}
