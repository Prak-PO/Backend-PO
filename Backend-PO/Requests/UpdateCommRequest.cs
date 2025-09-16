namespace Backend_PO.DTOs.Requests
{
    public class UpdateCommentRequest
    {
        public string Content { get; set; } = string.Empty;
        public int? UserId { get; set; } // Если не нужно менять
        public int? KursId { get; set; } // Если не нужно менять
    }
}