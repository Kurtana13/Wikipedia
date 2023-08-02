using System.ComponentModel.DataAnnotations;

namespace Wikipedia.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }


        public virtual List<Article>? articles { get; set; }
        public virtual List<Comment>? comments { get; set; }

    }
}
