using System.ComponentModel.DataAnnotations;

namespace Backend_PO.DTOs.Requests
{
    public class CreateFeedbackRequest
    {
        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public string? Notes { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "KursId is required")]
        public int KursId { get; set; }
    }
}