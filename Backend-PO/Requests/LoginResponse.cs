namespace Backend_PO.DTOs.Responses
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}