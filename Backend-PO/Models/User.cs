using System;
using System.Collections.Generic;

namespace Backend_PO.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Kurs> AuthoredCourses { get; set; } = new List<Kurs>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}


