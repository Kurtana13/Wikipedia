using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wikipedia.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter text")]
        public string? Content { get; set; }

        //Article
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article? Article { get; set; }

        //User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
