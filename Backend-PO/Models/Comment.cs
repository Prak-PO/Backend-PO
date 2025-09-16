using System;

namespace Backend_PO.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid KursId { get; set; }
        public Kurs Kurs { get; set; } = null!;
    }
}



