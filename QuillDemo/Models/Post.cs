using System.ComponentModel.DataAnnotations;

namespace QuillDemo.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; } // HTML from Quill

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
