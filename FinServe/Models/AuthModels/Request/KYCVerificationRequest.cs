public class KYCVerificationRequest
{
    public Guid UserId { get; set; }
    public string DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public IFormFile Document { get; set; } 
}
