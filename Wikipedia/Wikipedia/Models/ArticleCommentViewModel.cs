using Microsoft.AspNetCore.Mvc;

namespace Wikipedia.Models
{
    public class ArticleCommentViewModel
    {
        public ArticleCommentViewModel(List<Article> articles)
        {
            Articles = articles;
        }

        public List<Article> Articles { get; set; }
        public Comment Comment { get; set; } = null;
        [HiddenInput]
        public Article Article { get; set; } = null;
    }
}
