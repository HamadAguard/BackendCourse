using System;
using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is a must!")]
        public string Title { get; set; } = string.Empty;
        [Required]
        //[MinLength(10, ErrorMessage = "Content must be at least 10 characters long.")]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}