using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_PO.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [Required]
        public int KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;
    }
}



