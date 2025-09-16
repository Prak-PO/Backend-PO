using System.ComponentModel.DataAnnotations;

public class CreateCommentRequest
{
    [Required]
    [StringLength(1000)]
    public string Content { get; set; } = string.Empty;

    [Required]
    public int UserId { get; set; }

    [Required]
    public int KursId { get; set; }
}