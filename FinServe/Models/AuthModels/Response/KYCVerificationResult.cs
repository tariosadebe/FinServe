public class KYCVerificationResult
{
    public Guid Id { get; set; }  
    public string UserId { get; set; }  
    public bool Success { get; set; }
    public string Message { get; set; }
    public string VerificationDocument { get; set; }
    public DateTime VerificationDate { get; set; }
    public bool IsVerified { get; set; }
    public bool Succeeded { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
