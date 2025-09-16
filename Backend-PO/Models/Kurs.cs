using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend_PO.Models
{
    public class Kurs
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string VideoUrl { get; set; } = string.Empty;
    }
}


