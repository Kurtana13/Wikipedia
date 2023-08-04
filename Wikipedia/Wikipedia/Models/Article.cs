using System.ComponentModel.DataAnnotations;

namespace Wikipedia.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter text!")]
        public string Title { get; set; }
        public string? Content { get; set; }

        [Required(ErrorMessage = "Please enter user ID!")]
        public int UserId { get; set; }
        public User? User { get; set; }


        public List<Comment>? Comments { get; set; }
    }
}
