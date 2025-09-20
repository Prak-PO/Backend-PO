using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_PO.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [Required]
        public int KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;
    }
}



