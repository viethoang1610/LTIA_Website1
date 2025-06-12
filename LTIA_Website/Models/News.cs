using System;
using System.ComponentModel.DataAnnotations;

namespace LTIA_website.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = default!;

        public string Summary { get; set; } = default!;

        [Required]
        public string Content { get; set; } = default!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
