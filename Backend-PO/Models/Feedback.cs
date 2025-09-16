using System;

namespace Backend_PO.Models
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;
    }
}



