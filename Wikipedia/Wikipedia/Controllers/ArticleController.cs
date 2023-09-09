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
        public ActionResult Index(Comment comment, int articleId)
        {
            if (ModelState.IsValid)
            {
                Article? article = _db.Article.Find(articleId);
                comment.ArticleId = articleId;
                article.Comments.Add(comment);
                _db.Comment.Add(comment);
                _db.SaveChanges();
                return View(new ArticleCommentViewModel(_db.Article.ToList()));
            }
            return View(new ArticleCommentViewModel(_db.Article.ToList()));
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
