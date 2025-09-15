using System;
using System.Collections.Generic;

namespace Backend_PO.Models
{
    public class Kurs
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}


