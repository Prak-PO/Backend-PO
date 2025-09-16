using System.ComponentModel.DataAnnotations;

namespace Backend_PO.DTOs.Requests
{
    public class UpdateFeedbackRequest
    {
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int? Rating { get; set; }

        public string? Notes { get; set; }
    }
}