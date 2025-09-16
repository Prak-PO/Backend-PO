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

        public string VideoUrl { get; set; } = string.Empty;

        // Навигации к комментариям/отзывам убраны по требованиям
    }
}


